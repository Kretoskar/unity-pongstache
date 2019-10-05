﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField]
        private ControllersSO _controllersSO;

        #region Singleton

        private static GameSettings _instance;
        public static GameSettings Instance { get => _instance; }


        private void Awake()
        {
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

        public float WallWidth { get => _controllersSO.WallWidth; }
        public string WallsParentName { get => _controllersSO.WallsParentName; }
        public string LeftWallName { get => _controllersSO.LeftWallName; }
        public string RightWallName { get => _controllersSO.RightWallName; }
        public string TopWallName { get => _controllersSO.TopWallName; }
        public string BotWallName { get => _controllersSO.BotWallName; }
        public float BaseThreatSpeed { get => _controllersSO.BaseThreatSpeed; }
    }
}
