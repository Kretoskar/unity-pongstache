﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private BallSO _ballSo;

        public float BaseBallSpeed { get => _ballSo.BaseBallSpeed; }
        public float RandomFactorAfterHittingPlayer { get => _ballSo.RandomFactorAfterHittingPlayer; }
        public float YTweakAfterCollision { get => _ballSo.YTweakAfterCollision; }
        public float XTweakAfterCollision { get => _ballSo.XTweakAfterCollision; }
    }
}