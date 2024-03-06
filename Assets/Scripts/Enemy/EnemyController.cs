using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public Transform target;
    public Transform PointPos;

    public float speed;
    public float maxRange;
    public float minRange;

    public bool checkPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
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
        animator.SetFloat("MoveX", (PointPos.transform.position.x - transform.position.x));
        transform.position = Vector3.MoveTowards(transform.position, PointPos.position, speed *Time.deltaTime);

        checkPoint = true;
        if(transform.position.x == PointPos.position.x)
           {
            animator.SetBool("Moving", false);
           }
    }
}
