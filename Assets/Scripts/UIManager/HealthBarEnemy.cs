using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    EnemyAI enemyAI;

    void Start()
    {
        enemyAI = FindAnyObjectByType<EnemyAI>();
    }
    void Update()
    {
        if(enemyAI.healthBar == true )
        {
            transform.localScale = enemyAI.transform.localScale;
        }
    }
}
