using UnityEngine;

namespace RopeGame.Puzzle.Nodes
{
    public class NodeHighlight : MonoBehaviour
    {
        private SpriteRenderer _highlight;

        private void Awake()
        {
            _highlight = GetComponent<SpriteRenderer>();
            _highlight.enabled = false;
        }

        private void OnMouseEnter()
        {
            _highlight.enabled = true;
        }

        private void OnMouseExit()
        {
            _highlight.enabled = false;
        }
    }
}