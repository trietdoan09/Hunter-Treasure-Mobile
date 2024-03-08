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

    public bool spawn;

    EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponentInChildren<EnemyHealth>();

        timeCount = timeRespawn;
    }

    void Update()
    {
        if (enemyHealth.dead == true)
        {
            timeCount -= Time.deltaTime;
        }
    }

    public void SpawnEnemy()
    {
        enemyHealth.dead = false;
        spawn = false;
        timeCount = timeRespawn;
        Instantiate(enemyPrefab, transform);
    }
}
