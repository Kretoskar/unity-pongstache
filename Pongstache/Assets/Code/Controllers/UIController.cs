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
        private GameObject _inGameUI;
        [SerializeField]
        private GameObject _menuUI;
        [SerializeField]
        private TextMeshProUGUI _scoreText;
        [SerializeField]
        private TextMeshProUGUI _highScoreText;

        private ScoreController _scoreController;
        private GameStateController _gameStateController;

        private void Start()
        {
            _scoreController = GetComponent<ScoreController>();
            _gameStateController = GetComponent<GameStateController>();
            UpdateUI();
            _scoreController.ScoreChanged += UpdateUI;
            _gameStateController.StartGameEvent += HideMenuUI;
        }

        private void UpdateUI()
        {
            _scoreText.text = _scoreController.Score.ToString();
        }

        private void HideMenuUI()
        {
            _menuUI.SetActive(false);
            _inGameUI.SetActive(true);
        }
    }
}