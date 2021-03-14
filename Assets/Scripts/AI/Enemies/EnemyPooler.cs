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
    public GameObject enemy;
    private enum eEnemies
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

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        //public List<Pool> pools;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

    // Update is called once per frame
    void Update()
    {
        int enemy = Random.Range(1, 4);
    }
}
