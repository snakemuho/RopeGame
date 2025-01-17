using System;
using RopeGame.Score.Interfaces;

namespace RopeGame.Score
{
    public class ScoreTracker : IScoreTracker
    {
        public int Score { get; private set; }
        public Action<int> OnScoreUpdated { get; set; }

        public void UpdateScore(int amount)
        {
            Score += amount;
            OnScoreUpdated?.Invoke(amount);
        }
    }
}