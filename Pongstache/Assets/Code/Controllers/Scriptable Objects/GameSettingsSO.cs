using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Controllers/GameSettings")]
    public class GameSettingsSO : ScriptableObject
    {
        [Header("Boundaries")]
        [SerializeField]
        private float _wallWidth = 1;

        [SerializeField]
        private string _wallsParentName = "Boundaries";

        [SerializeField]
        private string _leftWallName = "Left wall";

        [SerializeField]
        private string _rightWallName = "Right wall";

        [SerializeField]
        private string _topWallName = "Top wall";

        [SerializeField]
        private string _botWallName = "Bot wall";

        [Header("Threats")]
        [SerializeField]
        [Range(0.1f, 10)]
        private float _baseThreatSpeed = 1;

        [SerializeField]
        [Range(0.1f, 10)]
        private float _ySpawnPosition = 6;

        [SerializeField]
        [Range(0.1f, 10)]
        private float _maxTimeBetweenSpawns = 2f;

        [SerializeField]
        [Range(0, 120)]
        private float _timeFromMinToMaxTime = 60;

        [SerializeField]
        private AnimationCurve _spawnCurve;

        public float WallWidth { get => _wallWidth; }
        public string WallsParentName { get => _wallsParentName; }
        public string LeftWallName { get => _leftWallName; }
        public string RightWallName { get => _rightWallName; }
        public string TopWallName { get => _topWallName; }
        public string BotWallName { get => _botWallName; }
        public float BaseThreatSpeed { get => _baseThreatSpeed; }
        public float YSpawnPosition { get => _ySpawnPosition; }
        public float MaxTimeBetweenSpawns { get => _maxTimeBetweenSpawns; }
        public float TimeFromMinToMaxTime { get => _timeFromMinToMaxTime; }
        public AnimationCurve SpawnCurve { get => _spawnCurve; }
    }

}