using System;
using RopeGame.Puzzle.Ropes.Interfaces;
using UnityEngine;

namespace RopeGame.Puzzle.Nodes
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private GameObject _highlight;
        private Vector2 _dragOffset;
        private IRopeIntersectionChecker _intersectionChecker;
        private IRopeMover _ropeMover;
        private Camera _camera;
        private bool _disabled;
    
        public Action OnStartDrag;
        public Action OnDrag;
        public Action OnEndDrag;
    
        public void Initialize(IRopeMover ropeMover, IRopeIntersectionChecker intersectionChecker)
        {
            _ropeMover = ropeMover;
            _intersectionChecker = intersectionChecker;
            _camera = Camera.main;
        }

        public void Disable()
        {
            _highlight.SetActive(false);
            _disabled = true;
        }

        private void OnMouseEnter()
        {
            if (_disabled) return;
            _highlight.SetActive(true);
        }

        private void OnMouseExit()
        {
            if (_disabled) return;
            _highlight.SetActive(false);
        }

        private void OnMouseDown()
        {
            if (_disabled) return;
            StartDragging(_camera.ScreenToWorldPoint(Input.mousePosition));
        }

        private void OnMouseDrag()
        {
            if (_disabled) return;
            Drag(_camera.ScreenToWorldPoint(Input.mousePosition));
        }

        private void OnMouseUp()
        {
            if (_disabled) return;
            StopDragging();
        }

        private void StartDragging(Vector2 touchPosition)
        {
            _dragOffset = (Vector2)transform.position - touchPosition;
            OnStartDrag?.Invoke();
        }

        private void Drag(Vector2 touchPosition)
        {
            if (transform.position == (Vector3)(touchPosition + _dragOffset)) return;
            transform.position = touchPosition + _dragOffset;
            _ropeMover.MoveRopes();
            _intersectionChecker.CheckIntersections();
            OnDrag?.Invoke();
        }

        private void StopDragging()
        {
            _intersectionChecker.CheckIfSolved();
            OnEndDrag?.Invoke();
        }
    }
}
