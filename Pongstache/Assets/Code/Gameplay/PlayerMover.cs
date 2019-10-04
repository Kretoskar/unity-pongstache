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
    public class PlayerMover : MonoBehaviour
    {
        private Camera _mainCamera;
        private Player _player;
        private float _distanceFromFingerToPlayer;
        private float _clampValue;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _player = GetComponent<Player>();
            if(_player.CalculateClampAccordingToScreenSize)
            {
                _clampValue = 
                    _mainCamera.aspect * _mainCamera.orthographicSize - _player.PlayerWidth/2 - _player.ClampOffset;
            }
            else
            {
                _clampValue = _player.Clamp;
            }
        }

        public void CalculateDistanceFromFingerToPlayer(float touchXPosition)
        {
            _distanceFromFingerToPlayer = touchXPosition - transform.position.x;
        }

        public void Move(float touchXPosition)
        {
            float xPos = Mathf.Clamp
                (((touchXPosition - _distanceFromFingerToPlayer) * _player.Speed),
                (-1 * _clampValue),
                (_clampValue));
            float yPos = transform.position.y;

            transform.position = new Vector2(xPos, yPos);
        }
    }
}
