using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Controllers;
using System;

namespace Game.Gameplay
{
    /// <summary>
    /// Ball state machine
    /// </summary>
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.GetComponent<Player>() != null)
            {
                TweakCollisionAfterCollidingWithPlayer();
                return;
            }
            else
            {
                TweakCollisionAfterCollision();
            }
        }

        private void TweakCollisionAfterCollidingWithPlayer()
        {
            float xTweak = -_ball.RandomFactorAfterHittingPlayer * (_player.transform.position.x - transform.position.x);
            float yTweak = 0;
            Vector2 velTweak = new Vector2(xTweak, yTweak);
            if (_hasGameStarted)
                _ballRigidbody.velocity += velTweak;
        }


        private void TweakCollisionAfterCollision()
        {
            Vector2 velocityTweak = new Vector2
                (UnityEngine.Random.Range(-_ball.XTweakAfterCollision, _ball.XTweakAfterCollision),
                (UnityEngine.Random.Range(-_ball.YTweakAfterCollision, _ball.YTweakAfterCollision)));
            if (_hasGameStarted)
            {
                _ballRigidbody.velocity += velocityTweak;
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