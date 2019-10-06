using Game.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay
{
    /// <summary>
    /// Restarts game when ball hits it, 
    /// disables threats
    /// </summary>
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
            Threat collThreat = collGO.GetComponent<Threat>();
            if (collThreat != null)
            {
                collThreat.DisableThreat();
            }
            else if (collGO.GetComponent<Ball>() != null)
            {
                GameStateController.Instance.RestartGame();
            }
        }
    }
}
