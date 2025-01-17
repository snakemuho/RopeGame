using System;

namespace RopeGame.Score.Interfaces
{
    public interface IScoreTracker
    {
        public int Score { get; }
        public Action<int> OnScoreUpdated { get; set; }
        public void UpdateScore(int amount);
    }
}