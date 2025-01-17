using System.Collections.Generic;
using UnityEngine;

namespace RopeGame.Puzzle.Data
{
    [CreateAssetMenu(menuName = "Create PuzzleNodesRopes", fileName = "PuzzleNodesRopes", order = 0)]
    public class PuzzleNodesRopes : ScriptableObject
    {
        public GameObject NodePrefab;
        public AudioClip NodeClickSound;
        public GameObject RopePrefab;
        public AudioClip RopeDragSound;
        public List<NodeSettings> NodesSettings;
        public List<RopeSettings> RopesSettings;
    }
}