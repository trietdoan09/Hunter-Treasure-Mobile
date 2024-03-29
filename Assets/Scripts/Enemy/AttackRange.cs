using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject skill;
    public Transform targetPosition;

    public void DamageRange()
    {
        Instantiate(skill, targetPosition);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnemyHealth enemyHealth = GetComponentInParent<EnemyHealth>();
            enemyHealth.health -= 50;

        }
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
