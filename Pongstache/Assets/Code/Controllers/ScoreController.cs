using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        private const string HighScorePP = "HighScore";
        private int _score;
        private int _highScore;

        public event Action ScoreChanged;

        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
                if (_score < 0)
                    _score = 0;
                if (_score > HighScore)
                    HighScore = _score;
                ScoreChanged?.Invoke();
            }
        }

        public int HighScore {
            get
            {
                return PlayerPrefs.GetInt(HighScorePP, 0);
            }
            set
            {
                PlayerPrefs.SetInt(HighScorePP, value);
            }
        }
    }
}
