using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
   
    public float timeRespawn;
    public float timeCount;

    void Start()
    {
        timeCount = timeRespawn;
    }

    void Update()
    {

        Animator animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                SpawnEnemy();
            }
        }
    }


    public void SpawnEnemy()
    {
        timeCount = timeRespawn;

        EnemyHealth enemyHealth = GetComponentInChildren<EnemyHealth>();
        enemyHealth.SpawnEnemy();
    }
}
