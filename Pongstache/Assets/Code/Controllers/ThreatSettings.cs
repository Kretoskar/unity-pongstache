using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class ThreatSettings : MonoBehaviour
    {
        [SerializeField]
        private ThreatsSO _threatsSO;

        public List<ThreatBlueprint> Threats { get => _threatsSO.Threats; }
    }
}