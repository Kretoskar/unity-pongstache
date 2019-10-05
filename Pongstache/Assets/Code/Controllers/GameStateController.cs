using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class GameStateController : MonoBehaviour
    {
        private static GameStateController _instance;
        public static GameStateController Instance { get => _instance; }

        public bool IsGameOn { get; private set; }

        public event Action StartGameEvent;    

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

        private void SetupSingleton()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
    }
}