using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public float speed;
     float right, left, direction;
    public float distanceMovement;

    EnemyMovement enemyMovement;

    public float idleDuration;
    float idleTimer;

    Animator animator;
    public bool healthBar;
    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovement = FindAnyObjectByType<EnemyMovement>();

        var currentPosition = transform.position;
         right = currentPosition.x + distanceMovement;
         left = currentPosition.x - distanceMovement;
         direction = right;
    }
 
    private void Update()
    {
        animator.SetBool("Run", false);

        
        animator.SetTrigger("Idle");
        var playerPosition = target.transform.position;
        var enemyPosition = transform.position;

        /* if (playerPosition.x > left && playerPosition.x < right)
         {
             transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, speed * Time.deltaTime);
         }*/
        if (enemyMovement.EnemyMove())
        {
            transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, speed * Time.deltaTime);
        }
        else
        {
            if (enemyPosition.x >= right )
            {
                idleTimer += Time.deltaTime;
                if ( idleTimer >= idleDuration )
                {
                    idleTimer = 0;
                    direction = left;  
                }
            }
           
            else if(enemyPosition.x <= left )
            {
                idleTimer += Time.deltaTime;
                if( idleTimer >= idleDuration )
                {
                    idleTimer = 0;
                    direction = right;
                }
            }
            else
            {
                animator.SetBool("Run", true);

            }
            transform.position = Vector3.MoveTowards(enemyPosition, new Vector3(direction, enemyPosition.y, 0), speed * Time.deltaTime);
        }
        if(enemyPosition.x > direction)
        {
            transform.localScale = new Vector3(-1,1,1);
            healthBar = true;
        }
        else if(enemyPosition.x < direction)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
}