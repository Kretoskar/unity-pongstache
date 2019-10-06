using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class ObjectPooler : MonoBehaviour
    {
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

        [SerializeField]
        private List<Pool> _pools;

        private ThreatSettings _threatSettings;

        public Dictionary<string, Queue<GameObject>> _poolDictionary;

        #region Singleton

        private static ObjectPooler _instance;
        public static ObjectPooler Instance { get => _instance; }

        private void SetupSingleton()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        private void Awake()
        {
            SetupSingleton();
            _threatSettings = GetComponent<ThreatSettings>();
        }

        private void Start()
        {
            SetupPools();
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if(!_poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag: " + tag + " doesn't exist");
                return null;
            }

            GameObject objToSpawn = _poolDictionary[tag].Dequeue();

            objToSpawn.SetActive(true);
            objToSpawn.transform.position = position;
            objToSpawn.transform.rotation = rotation;

            IPooledObject pooledObj = objToSpawn.GetComponent<IPooledObject>();

            if (pooledObj != null)
                pooledObj.OnObjectSpawn();

            _poolDictionary[tag].Enqueue(objToSpawn);

            return objToSpawn;
        }

        private void SetupPools()
        {
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in _pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                GameObject parent = new GameObject(pool.Tag);

                foreach (ThreatBlueprint threat in _threatSettings.Threats)
                {
                    pool.Prefabs.Add(threat);
                }


                for (int i = 0; i < pool.Size; i++)
                {
                    int r = UnityEngine.Random.Range(0, pool.Prefabs.Count);
                    GameObject obj = Instantiate(pool.Prefabs[r].Prefab, parent.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                    Threat threat = obj.GetComponent<Threat>();
                    if(threat != null)
                    {
                        threat.Speed = pool.Prefabs[r].Speed;
                    }
                }
                _poolDictionary.Add(pool.Tag, objectPool);
            }
        }
    }

}