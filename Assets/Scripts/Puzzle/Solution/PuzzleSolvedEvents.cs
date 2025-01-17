using System;
using RopeGame.Puzzle.Solution.Interfaces;

namespace RopeGame.Puzzle.Solution
{
    public class PuzzleSolvedEvents : IPuzzleSolvedEvents
    {
        public Action OnPuzzleSolved { get; set; }
        public Action OnPuzzleSkipped { get; set; }
    }
}