using Game.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathZone : MonoBehaviour
    {
        private void Start()
        {
            // Add rigidbody for collisions to be detected
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject collGO = collision.gameObject;
            if (collGO.GetComponent<Threat>() != null)
            {
                Destroy(collGO, 1);
            }
            else if (collGO.GetComponent<Ball>() != null)
            {
                GameStateController.Instance.RestartGame();
            }
        }
    }
}
