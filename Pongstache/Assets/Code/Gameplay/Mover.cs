using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    /// <summary>
    /// Move the player according to user's input
    /// </summary>
    [RequireComponent(typeof(Player))]
    public class Mover : MonoBehaviour
    {
        private Camera _mainCamera;
        private Player _player;
        private float _distanceFromFingerToPlayer;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            MoveThePlayer();
        }

        private void MoveThePlayer()
        {
            if(Input.touchCount > 0)
            {
                Touch userTouch = Input.GetTouch(0);
                if(userTouch.phase == TouchPhase.Began)
                {
                    CalculateDistanceFromFingerToPlayer(_mainCamera.ScreenToWorldPoint(userTouch.position).x);
                }
                else if (userTouch.phase == TouchPhase.Moved)
                {
                    Move(_mainCamera.ScreenToWorldPoint(userTouch.position).x);
                }
            }
        }

        private void CalculateDistanceFromFingerToPlayer(float touchXPosition)
        {
            _distanceFromFingerToPlayer = touchXPosition - transform.position.x;
        }

        private void Move(float touchXPosition)
        {
            float xPos = Mathf.Clamp
                (((touchXPosition - _distanceFromFingerToPlayer) * _player.Speed),
                (-1 * _player.Clamp),
                (_player.Clamp));
            float yPos = transform.position.y;

            transform.position = new Vector2(xPos, yPos);
        }
    }
}
