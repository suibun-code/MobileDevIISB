using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    EnemyPooler enemyPool;

    private void Start()
    {
        enemyPool = EnemyPooler.Instance;
    }
    private void FixedUpdate()
    {
        enemyPool.SpawnFromPool("enemy", transform.position, Quaternion.identity);
    }
}
