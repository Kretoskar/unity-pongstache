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

        private void Awake()
        {
            IsGameOn = false;
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