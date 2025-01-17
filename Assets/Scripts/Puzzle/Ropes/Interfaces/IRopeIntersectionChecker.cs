using System.Collections.Generic;

namespace RopeGame.Puzzle.Ropes.Interfaces
{
    public interface IRopeIntersectionChecker
    {
        public void CheckIntersections();
        public void CheckIfSolved();
        void SetRopes(List<Rope> ropes);
    }
}