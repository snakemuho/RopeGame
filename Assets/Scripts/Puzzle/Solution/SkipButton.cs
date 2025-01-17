using RopeGame.Puzzle.Solution.Interfaces;
using UnityEngine;

namespace RopeGame.Puzzle.Solution
{
    public class SkipButton : MonoBehaviour
    {
        private IPuzzleSkipper _puzzleSkipper;
        
        public void Initialize(IPuzzleSkipper puzzleSkipper)
        {
            _puzzleSkipper = puzzleSkipper;
        }

        public void SkipPuzzle()
        {
            _puzzleSkipper.SkipPuzzle();
        }
    }
}