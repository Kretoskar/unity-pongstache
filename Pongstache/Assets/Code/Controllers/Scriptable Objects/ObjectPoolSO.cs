using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    [CreateAssetMenu(fileName = "ObjectPoolSettings", menuName = "Controllers/ObjectPool")]
    public class ObjectPoolSO : ScriptableObject
    {

        [SerializeField]
        private List<Pool> _pools;

        public List<Pool> Pools { get => _pools; }
    }

    [System.Serializable]
    public class Pool
    {
        [SerializeField]
        private string _tag;
        [SerializeField]
        private int _size;

        private List<ThreatBlueprint> _prefabs = new List<ThreatBlueprint>();

        public string Tag { get => _tag; }
        public List<ThreatBlueprint> Prefabs { get => _prefabs; set => _prefabs = value; }
        public int Size { get => _size; }
    }
}