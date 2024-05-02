using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        EnemyHealth enemyHealth = GetComponentInParent<EnemyHealth>();
    //        enemyHealth.health -= 50;

    //    }
    //}

    public void DamagePlayer()
    {
        EnemyAttack enemyAttack = GetComponentInParent<EnemyAttack>();

        enemyAttack.DamagePlayer();

    }

    public void DamageRange()
    {
        EnemyAttack enemyAttack = GetComponentInParent<EnemyAttack>();
        enemyAttack.DamageRange();
    }


    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
