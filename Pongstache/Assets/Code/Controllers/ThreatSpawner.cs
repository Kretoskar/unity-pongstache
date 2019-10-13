using Game.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    /// <summary>
    /// Spawns threats withing a coroutine.
    /// Uses object pooling
    /// </summary>
    public class ThreatSpawner : MonoBehaviour
    {
        private float _timer;
        private float _xSpawnPosMin;
        private float _xSpawnPosMax;
        private float _xSpawnBoundary;
        private GameSettings _gameSettings;
        private GameStateController _gameStateController;
        private Camera _mainCamera;

        private void Awake()
        {
            _timer = 0;
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _gameSettings = GetComponent<GameSettings>();
            _gameStateController = GetComponent<GameStateController>();
            _gameStateController.StartGameEvent += StartSpawning;
            CalculateSpawnBoundary();
        }

        private void Update()
        {
            if (Time.time < _gameSettings.TimeFromMinToMaxTime)
                _timer = Time.time;
        }

        private void StartSpawning()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private void CalculateSpawnBoundary()
        {
            float horizontalScreenToWorld = _mainCamera.aspect * _mainCamera.orthographicSize;
            _xSpawnBoundary = horizontalScreenToWorld;
        }

        /// <summary>
        /// Spawn threats continously
        /// </summary>
        /// <returns>time to spawn next wave</returns>
        private IEnumerator SpawnCoroutine()
        {
            float timeToSpawn = _gameSettings.SpawnCurve.Evaluate(_timer / _gameSettings.TimeFromMinToMaxTime);
            timeToSpawn *= _gameSettings.MaxTimeBetweenSpawns;
            yield return new WaitForSeconds(timeToSpawn);
            SpawnThreat();
            StartCoroutine(SpawnCoroutine());
        }

        /// <summary>
        /// Calculate spawn position and spawn one of the threats
        /// </summary>
        private void SpawnThreat()
        {
            //TODO: Change magic string
            Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-_xSpawnBoundary, _xSpawnBoundary), _gameSettings.YSpawnPosition);
            ObjectPooler.Instance.SpawnFromPool("Threats", spawnPosition, Quaternion.identity);
        }
    }
}