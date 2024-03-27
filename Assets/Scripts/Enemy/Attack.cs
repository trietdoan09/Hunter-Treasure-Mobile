using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void DamagePlayer()
    {
        EnemyAttack enemyAttack = GetComponentInParent<EnemyAttack>();

        enemyAttack.DamagePlayer();

    }
  
    private void Update()
    {
            if(Input.GetMouseButtonDown(0))
        {
            EnemyHealth enemyHealth = GetComponentInParent<EnemyHealth>();
            //enemyHealth.health -= 50;

        }
    }
}
