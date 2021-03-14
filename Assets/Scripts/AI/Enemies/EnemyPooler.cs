using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    [SerializeField]
    public GameObject Archer;
    public GameObject Mummy;
    public GameObject Swordsmen;
    public GameObject Wizard;

    //public class Pool

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary  = new Dictionary<string, Queue<GameObject>>();    
    }

}
