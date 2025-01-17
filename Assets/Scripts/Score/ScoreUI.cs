using RopeGame.Score.Interfaces;
using TMPro;
using UnityEngine;

namespace RopeGame.Score
{
    public class ScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private IScoreTracker _scoreTracker;

        public void Initialize(IScoreTracker scoreTracker)
        {
            _scoreTracker = scoreTracker;
            _text = GetComponent<TextMeshProUGUI>();
            _scoreTracker.OnScoreUpdated += amount =>
            {
                _text.text = amount.ToString();
            };
        }
    }
}