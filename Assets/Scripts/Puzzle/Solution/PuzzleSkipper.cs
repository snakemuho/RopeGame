using System.Collections.Generic;
using RopeGame.Puzzle.Data;
using RopeGame.Puzzle.Nodes;
using RopeGame.Puzzle.Ropes;
using RopeGame.Puzzle.Ropes.Interfaces;
using RopeGame.Puzzle.Solution.Interfaces;

namespace RopeGame.Puzzle.Solution
{
    public class PuzzleSkipper : IPuzzleSkipper
    {
        private List<Node> _nodes;
        private List<NodeSettings> _nodeSettings;
        private readonly IRopeIntersectionChecker _ropeIntersectionChecker;
        private readonly IRopeMover _ropeMover;
        private readonly IPuzzleSolvedEvents _puzzleSolvedEvents;
    
        public PuzzleSkipper(IRopeIntersectionChecker ropeIntersectionChecker, IRopeMover ropeMover, IPuzzleSolvedEvents puzzleSolvedEvents)
        {
            _ropeIntersectionChecker = ropeIntersectionChecker;
            _ropeMover = ropeMover;
            _puzzleSolvedEvents = puzzleSolvedEvents;
        }

        public void SetNodes(List<Node> nodes, List<NodeSettings> nodeSettings)
        {
            _nodes = nodes;
            _nodeSettings = nodeSettings;
        }
    
        public void SkipPuzzle()
        {
            for (int i = 0; i < _nodes.Count; i++)
            {
                _nodes[i].transform.position = _nodeSettings[i].WinPosition;
            }
            _ropeMover.MoveRopes();
            _ropeIntersectionChecker.CheckIntersections();
            _puzzleSolvedEvents.OnPuzzleSkipped?.Invoke();
        }
    }
}