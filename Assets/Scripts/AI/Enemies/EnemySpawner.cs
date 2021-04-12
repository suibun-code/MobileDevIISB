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
        enemyPool.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
    }
}
