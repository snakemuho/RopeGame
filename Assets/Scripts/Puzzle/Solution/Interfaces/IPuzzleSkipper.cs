using System.Collections.Generic;
using RopeGame.Puzzle.Data;
using RopeGame.Puzzle.Nodes;

namespace RopeGame.Puzzle.Solution.Interfaces
{
    public interface IPuzzleSkipper
    {
        public void SkipPuzzle();
        public void SetNodes(List<Node> nodes, List<NodeSettings> nodeSettings);
    }
}