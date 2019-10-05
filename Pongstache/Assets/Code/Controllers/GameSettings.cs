using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField]
        private ControllersSO _controllersSO;

        public float WallWidth { get => _controllersSO.WallWidth; }
        public string WallsParentName { get => _controllersSO.WallsParentName; }
        public string LeftWallName { get => _controllersSO.LeftWallName; }
        public string RightWallName { get => _controllersSO.RightWallName; }
        public string TopWallName { get => _controllersSO.TopWallName; }
        public string BotWallName { get => _controllersSO.BotWallName; }
    }
}
