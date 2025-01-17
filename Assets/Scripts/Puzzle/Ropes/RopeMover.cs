using System.Collections.Generic;
using RopeGame.Puzzle.Ropes.Interfaces;

namespace RopeGame.Puzzle.Ropes
{
    public class RopeMover : IRopeMover
    {
        private List<Rope> _ropes;

        public void SetRopes(List<Rope> ropes)
        {
            _ropes = ropes;
        }
        
        public void MoveRopes()
        {
            foreach (var rope in _ropes)
            {
                rope.Move();   
            }
        }
    }
}