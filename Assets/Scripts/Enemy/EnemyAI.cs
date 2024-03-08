using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float range;

    Transform target;
    Transform rightPos;
    float direction;

    public float idleDuration;
    float idleTimer;

    Animator animator;

    Vector2 currentPosition;
    Enemy enemy;
    EnemyMovement enemyMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<Enemy>();
        target = FindAnyObjectByType<PlayerMovement>().transform;
        rightPos = GetComponentInParent<EnemySpawn>().transform;
        enemyMovement = GetComponentInParent<EnemyMovement>();

         currentPosition = transform.position;
        
         direction = currentPosition.x;
    }
 
    private void Update()
    {
        animator.SetTrigger("Idle");
        if(!enemyMovement.EnemyMove())
        {
            EnemyMovement();
        }
       
        if(enemyMovement.EnemyMove() && Vector3.Distance(target.transform.position, transform.position) > range)
        {
              animator.SetBool("Moving", true);
              animator.SetFloat("MoveX", (target.transform.position.x - transform.position.x));

              transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

              if (Vector3.Distance(target.transform.position, transform.position) <= range)
              {
                  animator.SetBool("Moving", false);
              }
        }
                
        if(transform.position.x < currentPosition.x && Vector3.Distance(target.transform.position, transform.position) > range 
            || transform.position.x > rightPos.position.x && Vector3.Distance(target.transform.position, transform.position) > range)
        {
            animator.SetBool("Moving", true);
        }
    }
   void EnemyMovement()
    {
        animator.SetBool("Moving", true);

        if (transform.position.x >= rightPos.position.x)
        {
            MoveInDierection(currentPosition.x);
        }

        else if (transform.position.x <= currentPosition.x)
        {
            MoveInDierection(rightPos.position.x);
        }
        animator.SetFloat("MoveX", (direction - transform.position.x));

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(direction, transform.position.y, 0), speed * Time.deltaTime);

    }
   void MoveInDierection(float _direction)
    {
        animator.SetBool("Moving", false);

        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            idleTimer = 0;
            direction = _direction;
        }
    }
}