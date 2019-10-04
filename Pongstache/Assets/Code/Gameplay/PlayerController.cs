using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    /// <summary>
    /// Control player's state
    /// </summary>
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMover _mover;
        private Camera _mainCamera;

        private void Awake()
        {
            _mover = GetComponent<PlayerMover>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch userTouch = Input.GetTouch(0);
                if (userTouch.phase == TouchPhase.Began)
                {
                    _mover.CalculateDistanceFromFingerToPlayer(_mainCamera.ScreenToWorldPoint(userTouch.position).x);
                }
                else if (userTouch.phase == TouchPhase.Moved)
                {
                    _mover.Move(_mainCamera.ScreenToWorldPoint(userTouch.position).x);
                }
            }
        }
    }

}