using System.Collections.Generic;

namespace RopeGame.Puzzle.Ropes.Interfaces
{
    public interface IRopeMover
    {
        public void MoveRopes();
        void SetRopes(List<Rope> ropes);
    }
}