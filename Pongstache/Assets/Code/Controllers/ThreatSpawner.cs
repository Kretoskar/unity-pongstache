using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class ThreatSpawner : MonoBehaviour
    {
        private float _timer;
        private float _xSpawnPosMin;
        private float _xSpawnPosMax;
        private List<Threat> _threats;
        private GameSettings _gameSettings;

        private void Awake()
        {
            _timer = 0;
        }

        private void Start()
        {
            _gameSettings = GameSettings.Instance;
            _threats = _gameSettings.Threats;
            StartCoroutine(SpawnCoroutine());
        }

        private void Update()
        {
            if (Time.time < _gameSettings.TimeFromMinToMaxTime)
                _timer = Time.time;
        }

        /// <summary>
        /// Spawn threats continously
        /// </summary>
        /// <returns>time to spawn next wave</returns>
        private IEnumerator SpawnCoroutine()
        {
            float timeToSpawn = _gameSettings.SpawnCurve.Evaluate(_timer / _gameSettings.TimeFromMinToMaxTime);
            timeToSpawn *= _gameSettings.MaxTimeBetweenSpawns;
            print(timeToSpawn);
            yield return new WaitForSeconds(timeToSpawn);
            SpawnThreat();
            StartCoroutine(SpawnCoroutine());
        }

        /// <summary>
        /// Calculate spawn position and spawn one of the threats
        /// </summary>
        private void SpawnThreat()
        {
            //TODO: Change magic numbers
            Vector2 spawnPosition = new Vector2(Random.Range(-3, 3), _gameSettings.YSpawnPosition);
            int spawnIndex = Random.Range(0, _threats.Count);
            Instantiate(_threats[spawnIndex], spawnPosition, Quaternion.identity);
        }
    }
}