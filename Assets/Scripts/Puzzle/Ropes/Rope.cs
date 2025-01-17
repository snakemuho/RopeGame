using UnityEngine;

namespace RopeGame.Puzzle.Ropes
{
    public class Rope : MonoBehaviour
    {
        public Transform NodeA;
        public Transform NodeB;
        private LineRenderer _lineRenderer;
        [SerializeField] private Texture _ropeRed, _ropeGreen;

        public void Initialize(Transform nodeA, Transform nodeB)
        {
            NodeA = nodeA;
            NodeB = nodeB;
            _lineRenderer = GetComponent<LineRenderer>();
        }
    
        public void Move()
        {
            _lineRenderer.SetPosition(0, NodeA.position);
            _lineRenderer.SetPosition(1, NodeB.position);
        }

        public void SetRopeColor(bool intersecting)
        {
            _lineRenderer.material.SetTexture("_MainTex", intersecting ? _ropeRed : _ropeGreen);
        }
    }
}