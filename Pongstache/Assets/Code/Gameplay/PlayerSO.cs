using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Gameplay/Player")]
    public class PlayerSO : ScriptableObject
    {
        [SerializeField]
        [Range(0.1f, 10f)]
        private float _playerSpeed;

        [SerializeField]
        private float _playerClamp;

        public float Speed { get => _playerSpeed; }
        public float Clamp { get => _playerClamp; }
    }
}
