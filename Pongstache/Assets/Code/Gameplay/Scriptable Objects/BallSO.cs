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
        private float _baseBallSpeed;

        [SerializeField]
        [Range(0.1f, 10)]
        private float _randomFactorAfterHittingPlayer;

        [SerializeField]
        [Range(0.1f, 10)]
        private float _xTweakAfterCollision;

        [SerializeField]
        [Range(0.1f, 10)]
        private float _yTweakAfterCollision;

        public float BaseBallSpeed { get => _baseBallSpeed; }
        public float RandomFactorAfterHittingPlayer { get => _randomFactorAfterHittingPlayer; }
        public float YTweakAfterCollision { get => _yTweakAfterCollision; }
        public float XTweakAfterCollision { get => _xTweakAfterCollision; }
    }

}