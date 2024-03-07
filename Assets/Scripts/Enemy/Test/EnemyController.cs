using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public Transform pointPos;
     Transform target;
     Transform homePos;

    public float speed;
    public float minRange;
    public float maxRange;

    bool checkHealth;

    EnemyHealth enemyHealth;
    EnemySpawn enemySpawn;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = FindAnyObjectByType<PlayerMovement>().transform;
        homePos = GetComponentInParent<EnemySpawn>().transform;

        enemyHealth = FindAnyObjectByType<EnemyHealth>();
        enemySpawn = FindAnyObjectByType<EnemySpawn>();
    }

    private void Update()
    {
        animator.SetTrigger("Idle");

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
            if (Vector3.Distance(target.position, transform.position) <= minRange)
            {
                animator.SetBool("Moving", false);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > maxRange)
        {
            GoPointPos();
        }
    }

    public void FollowPlayer()
    {
        animator.SetBool("Moving",true);
        animator.SetFloat("MoveX", (target.transform.position.x - transform.position.x));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoPointPos()
    {
        animator.SetFloat("MoveX", (homePos.transform.position.x - transform.position.x));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed *Time.deltaTime);
        checkHealth = true;

        if (transform.position.x == homePos.position.x)
           {
            animator.SetBool("Moving", false);
            if(checkHealth == true && enemyHealth.health < enemyHealth.maxHealth)
            {
                checkHealth = false;
                
                enemyHealth.health = enemyHealth.maxHealth;
                enemyHealth.heathSlider.value = enemyHealth.health;
            }
           }
    }

}
