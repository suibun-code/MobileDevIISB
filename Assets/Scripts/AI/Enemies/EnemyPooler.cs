using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    [SerializeField]
    public GameObject Archer;
    public GameObject Swordsmen;
    public GameObject Wizard;
    public GameObject Mummy;
    //public GameObject e;
    //public GameObject enemy;
    enum eEnemies
    {
        Archer,
        Swordsmen,
        Wizard,
        Mummy
    }

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject e;
        public int size;
    }

    public static EnemyPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    int enemy0 = (int)eEnemies.Archer;
    int enemy1 = (int)eEnemies.Swordsmen;
    int enemy2 = (int)eEnemies.Wizard;
    int enemy3 = (int)eEnemies.Mummy;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < 1; i++)
            {
                int enemy = Random.Range(0, 3);
                Debug.Log (enemy);
                switch (enemy)
                {
                    case 0:
                        pool.e = Archer;
                        Debug.Log(pool.e);
                        break;
                    case 1:
                        pool.e = Swordsmen;
                        Debug.Log(pool.e);
                        break;
                    case 2:
                        pool.e = Wizard;
                        Debug.Log(pool.e);
                        break;
                    case 3:
                        pool.e = Mummy;
                        Debug.Log(pool.e);
                        break;

                }
                GameObject obj = Instantiate(pool.e, transform.position, Quaternion.identity);
                obj.SetActive(true);
                objectPool.Enqueue(obj);
            }
           // poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(false);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


    // Update is called once per frame
    void Update()
    {
        
         
    }
}
