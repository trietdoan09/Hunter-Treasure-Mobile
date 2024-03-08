using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyTransform;

    public float timeRespawn;
    public float timeCount;

    void Start()
    {

        timeCount = timeRespawn;
    }

    void Update()
    {
        EnemyHealth enemyHealth = GetComponentInChildren<EnemyHealth>();
        if (enemyHealth == null)
        {
            timeCount -= Time.deltaTime;
        }
    }


    public void SpawnEnemy()
    {
        timeCount = timeRespawn;
        Instantiate(enemyPrefab, transform);

    }
}
