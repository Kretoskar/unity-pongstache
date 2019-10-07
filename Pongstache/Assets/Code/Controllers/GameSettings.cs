using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField]
        private GameSettingsSO _controllersSO;

        public float WallWidth { get => _controllersSO.WallWidth; }
        public string WallsParentName { get => _controllersSO.WallsParentName; }
        public string LeftWallName { get => _controllersSO.LeftWallName; }
        public string RightWallName { get => _controllersSO.RightWallName; }
        public string TopWallName { get => _controllersSO.TopWallName; }
        public string BotWallName { get => _controllersSO.BotWallName; }
        public float BaseThreatSpeed { get => _controllersSO.BaseThreatSpeed; }
        public float YSpawnPosition { get => _controllersSO.YSpawnPosition; }
        public float MaxTimeBetweenSpawns { get => _controllersSO.MaxTimeBetweenSpawns; }
        public float TimeFromMinToMaxTime { get => _controllersSO.TimeFromMinToMaxTime; }
        public AnimationCurve SpawnCurve { get => _controllersSO.SpawnCurve; }
    }
}
