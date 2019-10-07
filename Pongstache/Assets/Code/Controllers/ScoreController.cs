using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        private int _score;

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
                ScoreChanged?.Invoke();
            }
        }
    }
}
