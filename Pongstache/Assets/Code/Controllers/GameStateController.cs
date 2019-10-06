using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        public bool IsGameOn { get; private set; }

        public event Action StartGameEvent;

        #region Singleton

        private static GameStateController _instance;
        public static GameStateController Instance { get => _instance; }

        private void Awake()
        {
            IsGameOn = false;
            SetupSingleton();
        }

        private void SetupSingleton()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        public void StartGame()
        {
            StartGameEvent?.Invoke();
            IsGameOn = true;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}