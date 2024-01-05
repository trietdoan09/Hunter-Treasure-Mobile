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
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyMovement = FindAnyObjectByType<EnemyMovement>();

        var currentPosition = transform.position;
         right = currentPosition.x + distanceMovement;
         left = currentPosition.x - distanceMovement;
         direction = right;
    }
 
    private void Update()
    {
        animator.SetTrigger("Idle");
        var playerPosition = target.transform.position;
        var enemyPosition = transform.position;

        //var movement = transform.Find("Enemy"); ;
        //animator.SetFloat("Horizontal", movement.position.x);
        //animator.SetFloat("Run", movement.position.x);

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
            transform.position = Vector3.MoveTowards(enemyPosition, new Vector3(direction, enemyPosition.y, 0), speed * Time.deltaTime);
        }
    }
}