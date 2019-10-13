using Game.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    /// <summary>
    /// Player state machine
    /// </summary>
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMover _mover;
        private Camera _mainCamera;
        private GameStateController _gameStateController;

        private void Awake()
        {
            _mover = GetComponent<PlayerMover>();
        }

        private void Start()
        {
            _mainCamera = Camera.main;
            _gameStateController = FindObjectOfType<GameStateController>();
        }

        void Update()
        {
            StateMachine();
        }

        private void StateMachine()
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
                else if(userTouch.phase == TouchPhase.Ended)
                {
                    if (!_gameStateController.IsGameOn)
                    {
                        _gameStateController.StartGame();
                    }
                }
            }
        }
    }

}