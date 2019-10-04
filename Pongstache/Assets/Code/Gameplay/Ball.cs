using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private BallSO _ballSo;

        public float MaxBallSpeed { get => _ballSo.MaxBallSpeed; }
        public float YBallPushOnStart { get => _ballSo.YBallPushOnStart; }
    }
}