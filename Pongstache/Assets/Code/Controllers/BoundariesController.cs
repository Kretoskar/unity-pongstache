using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Gameplay;

namespace Game.Controllers
{
    /// <summary>
    /// Instantiates walls according to screen size
    /// </summary>
    [RequireComponent(typeof(GameSettings))]
    public class BoundariesController : MonoBehaviour
    {
        private float _wallWidth;
        private string _wallsParentName;
        private string _leftWallName;
        private string _rightWallName;
        private string _topWallName;
        private string _botWallName;

        private Camera _mainCamera;
        private GameSettings _gameSettings;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _gameSettings = GetComponent<GameSettings>();
        }

        private void Start()
        {
            _wallWidth = _gameSettings.WallWidth;
            _wallsParentName = _gameSettings.WallsParentName;
            _leftWallName = _gameSettings.LeftWallName;
            _rightWallName = _gameSettings.RightWallName;
            _topWallName = _gameSettings.TopWallName;
            _botWallName = _gameSettings.BotWallName;
            SetupWalls();
        }

        private void SetupWalls()
        {
            GameObject boundaries = new GameObject();
            boundaries.name = _wallsParentName;

            float verticalWallSize = _mainCamera.orthographicSize * 2 + _wallWidth * 2;
            float horizontalWallSize = _mainCamera.aspect * _mainCamera.orthographicSize * 2;

            //LeftWall
            float lxPos = (-1) * (_mainCamera.aspect * _mainCamera.orthographicSize + (_wallWidth / 2));
            GameObject leftWall = new GameObject();
            leftWall.transform.SetParent(boundaries.transform);
            leftWall.name = _leftWallName;
            leftWall.transform.position = new Vector2(lxPos, 0);
            BoxCollider2D leftWallCollider = leftWall.AddComponent<BoxCollider2D>();
            leftWallCollider.size = new Vector2(_wallWidth, verticalWallSize);

            //RightWall
            float rxPos = (_mainCamera.aspect * _mainCamera.orthographicSize + (_wallWidth / 2));
            GameObject rightWall = new GameObject();
            rightWall.transform.SetParent(boundaries.transform);
            rightWall.name = _rightWallName;
            rightWall.transform.position = new Vector2(rxPos, 0);
            BoxCollider2D rightWallCollider = rightWall.AddComponent<BoxCollider2D>();
            rightWallCollider.size = new Vector2(_wallWidth, verticalWallSize);

            //TopWall
            float tyPos = (_mainCamera.orthographicSize + _wallWidth / 2);
            GameObject topWall = new GameObject();
            topWall.transform.SetParent(boundaries.transform);
            topWall.name = _topWallName;
            topWall.transform.position = new Vector2(0, tyPos);
            BoxCollider2D topWallCollider = topWall.AddComponent<BoxCollider2D>();
            topWallCollider.size = new Vector2(horizontalWallSize, _wallWidth);

            //BotWall
            float byPos = (-_mainCamera.orthographicSize - _wallWidth / 2);
            GameObject botWall = new GameObject();
            botWall.transform.SetParent(boundaries.transform);
            botWall.name = _botWallName;
            botWall.transform.position = new Vector2(0, byPos);
            BoxCollider2D botWallCollider = botWall.AddComponent<BoxCollider2D>();
            botWallCollider.size = new Vector2(horizontalWallSize, _wallWidth);
            botWallCollider.isTrigger = true;
            botWall.AddComponent<DeathZone>();
        }
    }
}
