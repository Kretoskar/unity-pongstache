using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Gameplay/Player")]
    public class PlayerSO : ScriptableObject
    {
        [Header("Main properties")]
        [SerializeField]
        [Range(0.1f, 10f)]
        private float _playerSpeed;

        [Header("X axis clamp")]
        [SerializeField]
        private bool _calculateClampAccordingToScreenSize;

        [SerializeField]
        private float _customPlayerClamp;

        [SerializeField]
        [Range(0,10)]
        private float _playerWidth = 1;

        [SerializeField]
        [Range(0,1)]
        private float _clampOffset = 0.1f;

        public float Speed { get => _playerSpeed; }
        public float Clamp { get => _customPlayerClamp; }
        public bool CalculateClampAccordingToScreenSize { get => _calculateClampAccordingToScreenSize; }
        public float PlayerWidth { get => _playerWidth; }
        public float ClampOffset { get => _clampOffset; }
    }
}
