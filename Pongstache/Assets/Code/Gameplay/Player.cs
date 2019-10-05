using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    /// <summary>
    /// Player settings
    /// </summary>
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerSO _playerSettings;

        public float Speed { get => _playerSettings.Speed; }
        public float Clamp { get => _playerSettings.Clamp; }
        public bool CalculateClampAccordingToScreenSize { get => _playerSettings.CalculateClampAccordingToScreenSize; }
        public float PlayerWidth { get => _playerSettings.PlayerWidth; }
        public float ClampOffset { get => _playerSettings.ClampOffset; }
    }
}
