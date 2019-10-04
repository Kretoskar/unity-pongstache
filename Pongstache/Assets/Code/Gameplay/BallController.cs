using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Controllers;
using System;

namespace Game.Gameplay
{
    public class BallController : MonoBehaviour
    {
        private Player _player;
        private Ball _ball;
        private Rigidbody2D _ballRigidbody;
        private bool _hasGameStarted = false;

        private void Awake()
        {
            _ball = GetComponent<Ball>();
            _ballRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            if (_player == null)
                Debug.LogWarning("Can't find player");
            GameStateController.Instance.StartGameEvent += LaunchBall;
        }

        private void Update()
        {
            if (!_hasGameStarted)
            {
                StickBallToPaddle();
            }
            else
            {
                KeepConstantSpeed();
            }
        }

        /// <summary>
        /// Make sure the ball doesn't go wild 
        /// </summary>
        private void KeepConstantSpeed()
        {
            _ballRigidbody.velocity = _ball.MaxBallSpeed * (_ballRigidbody.velocity.normalized);
        }

        private void StickBallToPaddle()
        {
            float xPos = _player.transform.position.x;
            float yPos = transform.position.y;
            transform.position = new Vector2(xPos, yPos);
        }

        private void LaunchBall()
        {
            _hasGameStarted = true;
            _ballRigidbody.velocity = new Vector2(0, _ball.YBallPushOnStart);
        }
    }
}