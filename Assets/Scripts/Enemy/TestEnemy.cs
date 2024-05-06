using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    EnemyHealth enemyHealth;
    private void Start()
    {
        enemyHealth = FindAnyObjectByType<EnemyHealth>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            enemyHealth.health -= 50;

        }
    }
}
