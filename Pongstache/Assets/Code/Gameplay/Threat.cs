using Game.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class Threat : MonoBehaviour, IPooledObject
    {
        private GameSettings _gameSettings;

        public float Speed { get; set; }

        private void Start()
        {
            _gameSettings = GameSettings.Instance;
        }

        private void Update()
        {
            Move();
        }


        public void OnObjectSpawn()
        {
            //Do stuff on spawn
        }

        public void DisableThreat()
        {
            gameObject.SetActive(false);
        }

        private void Move()
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Ball>() != null)
                DisableThreat();
        }
    }
}