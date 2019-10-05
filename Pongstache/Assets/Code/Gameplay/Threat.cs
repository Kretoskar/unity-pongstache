using Game.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    public class Threat : MonoBehaviour
    {
        private GameSettings _gameSettings;

        private void Start()
        {
            _gameSettings = GameSettings.Instance;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.down * Time.deltaTime * _gameSettings.BaseThreatSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Ball>() != null)
                Destroy(gameObject);
        }
    }
}