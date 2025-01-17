using System.Collections.Generic;
using RopeGame.Puzzle.Data;
using RopeGame.Puzzle.Nodes;
using RopeGame.Puzzle.Ropes;
using UnityEngine;

namespace RopeGame.Puzzle.Spawn
{
    public class PuzzleSpawner : MonoBehaviour
    {
        public readonly List<Node> SpawnedNodes = new();
        public readonly List<Rope> SpawnedRopes = new();

        public void SpawnPuzzle(PuzzleNodesRopes puzzleNodesRopes)
        {
            foreach (var node in puzzleNodesRopes.NodesSettings)
            {
                var spawnedNode = Instantiate(puzzleNodesRopes.NodePrefab).GetComponent<Node>();
                spawnedNode.transform.position = node.StartPosition;
                SpawnedNodes.Add(spawnedNode);
            }

            foreach (var rope in puzzleNodesRopes.RopesSettings)
            {
                var spawnedRope = Instantiate(puzzleNodesRopes.RopePrefab).GetComponent<Rope>();
                spawnedRope.Initialize(SpawnedNodes[rope.IDNodeA - 1].transform, SpawnedNodes[rope.IDNodeB - 1].transform);
                SpawnedRopes.Add(spawnedRope);
            }
        }
    }
}