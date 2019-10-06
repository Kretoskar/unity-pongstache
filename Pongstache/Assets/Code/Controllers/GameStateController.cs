using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controllers
{
    /// <summary>
    /// Methods for starting and restarting game.
    /// Property with current game state 
    /// </summary>
    public class GameStateController : MonoBehaviour
    {
        public bool IsGameOn { get; private set; }

        public event Action StartGameEvent;

        #region Singleton

        private static GameStateController _instance;
        public static GameStateController Instance { get => _instance; }

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

        private void Awake()
        {
            IsGameOn = false;
            SetupSingleton();
        }

        public void StartGame()
        {
            StartGameEvent?.Invoke();
            IsGameOn = true;
        }

        /// <summary>
        /// Reset the scene
        /// </summary>
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}