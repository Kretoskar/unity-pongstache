using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Game.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        private ScoreController _scoreController;

        private void Start()
        {
            _scoreController = GetComponent<ScoreController>();
            UpdateUI();
            _scoreController.ScoreChanged += UpdateUI;
        }

        private void UpdateUI()
        {
            _text.text = _scoreController.Score.ToString();
        }
    }
}