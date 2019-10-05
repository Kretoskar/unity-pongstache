using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Gameplay
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            SceneManager.LoadScene(0);
        }
    }
}
