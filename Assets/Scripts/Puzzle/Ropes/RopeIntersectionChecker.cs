using System.Collections.Generic;
using RopeGame.Helpers;
using RopeGame.Puzzle.Ropes.Interfaces;
using RopeGame.Puzzle.Solution;
using RopeGame.Puzzle.Solution.Interfaces;

namespace RopeGame.Puzzle.Ropes
{
    public class RopeIntersectionChecker : IRopeIntersectionChecker
    {
        private List<Rope> _ropes;
        private readonly IPuzzleSolvedEvents _puzzleSolvedEvents;

        private HashSet<Rope> _intersectingRopes = new ();
        private HashSet<Rope> _newIntersectingRopes = new ();


        public RopeIntersectionChecker(IPuzzleSolvedEvents puzzleSolvedEvents)
        {
            _puzzleSolvedEvents = puzzleSolvedEvents;
        }

        public void SetRopes(List<Rope> ropes)
        {
            _ropes = ropes;
        }
        
        public void CheckIntersections()
        {
            _newIntersectingRopes.Clear();
        
            for (int i = 0; i < _ropes.Count; i++)
            {
                for (int j = i + 1; j < _ropes.Count; j++)
                {
                    Rope rope1 = _ropes[i];
                    Rope rope2 = _ropes[j];

                    if (ShareNode(rope1, rope2)) continue;

                    bool intersecting = LineIntersection.DoLinesIntersect(
                        rope1.NodeA.position, rope1.NodeB.position,
                        rope2.NodeA.position, rope2.NodeB.position
                    );

                    if (intersecting)
                    {
                        _newIntersectingRopes.Add(rope1);
                        _newIntersectingRopes.Add(rope2);
                    }
                }
            }

            foreach (var rope in _ropes)
            {
                bool isIntersecting = _newIntersectingRopes.Contains(rope);
                if (isIntersecting != _intersectingRopes.Contains(rope))
                {
                    rope.SetRopeColor(isIntersecting);
                }
            }

            (_intersectingRopes, _newIntersectingRopes) = (_newIntersectingRopes, _intersectingRopes);
        }

        public void CheckIfSolved()
        {
            if (_intersectingRopes.Count != 0) return;
        
            _puzzleSolvedEvents.OnPuzzleSolved?.Invoke();
        }

        bool ShareNode(Rope rope1, Rope rope2)
        {
            return rope1.NodeA == rope2.NodeA || rope1.NodeA == rope2.NodeB ||
                   rope1.NodeB == rope2.NodeA || rope1.NodeB == rope2.NodeB;
        }
    }
}
