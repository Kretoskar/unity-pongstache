using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(fileName = "BallSettings", menuName = "Gameplay/Ball")]
    public class BallSO : ScriptableObject
    {
        [SerializeField]
        [Range(0.1f, 20)]
        private float _maxBallSpeed;

        [SerializeField]
        [Range(0.1f,20)]
        private float _yBallPushOnStart;

        public float MaxBallSpeed { get => _maxBallSpeed; }
        public float YBallPushOnStart { get => _yBallPushOnStart; }
    }

}