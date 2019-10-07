using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay
{
    [System.Serializable]
    public class ThreatBlueprint
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        [Range(0.1f, 10)]
        private float _speed;

        [SerializeField]
        [Range(1, 10)]
        private int _shotsToDestroy;

        [SerializeField]
        [Range(1, 10)]
        private int _scoreToAdd;

        [SerializeField]
        private GameObject _prefab;

        public string Name { get => _name; }
        public float Speed { get => _speed; }
        public int ShotsToDestroy { get => _shotsToDestroy; }
        public int ScoreToAdd { get => _scoreToAdd; }
        public GameObject Prefab { get => _prefab; }
    }

    [CreateAssetMenu(fileName = "ThreatsSettings", menuName = "Gameplay/Threats")]
    public class ThreatsSO : ScriptableObject
    {
        [SerializeField]
        private List<ThreatBlueprint> _threats;

        public List<ThreatBlueprint> Threats { get => _threats; }
    }
}
