using System;

namespace RopeGame.Puzzle.Solution.Interfaces
{
    public interface IPuzzleSolvedEvents
    {
        public Action OnPuzzleSolved { get; set; }
        public Action OnPuzzleSkipped { get; set;}
    }
}