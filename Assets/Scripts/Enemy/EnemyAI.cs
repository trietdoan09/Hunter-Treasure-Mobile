using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public Transform right;
    float direction;

    Enemy enemy;

    public float idleDuration;
    float idleTimer;

    Animator animator;
    public bool healthBar;

    Vector2 playerPosition;
    Vector2 enemyPosition;
    Vector2 currentPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemy = FindAnyObjectByType<Enemy>();

         currentPosition = transform.position;
        
         direction = currentPosition.x;
    }
 
    private void Update()
    {
        animator.SetTrigger("Idle");
        animator.SetBool("Run", true);

        playerPosition = target.transform.position;
        enemyPosition = transform.position;

        EnemyMovement();

        if (enemy.check == true)
        {
            transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, speed * Time.deltaTime);
            animator.SetBool("Run", true);

            if (transform.position.x < playerPosition.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                healthBar = true;
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if(transform.position.x < currentPosition.x || transform.position.x > right.position.x)
        {
            animator.SetBool("Run", true);
        }
    }
   void EnemyMovement()
    {
        animator.SetBool("Run", true);

        if (enemyPosition.x >= right.position.x)
        {
            MoveInDierection(currentPosition.x);
        }

        else if (enemyPosition.x <= currentPosition.x)
        {
            MoveInDierection(right.position.x);
        }

        transform.position = Vector3.MoveTowards(enemyPosition, new Vector3(direction, enemyPosition.y, 0), speed * Time.deltaTime);

        if (enemyPosition.x < direction)
        {
            transform.localScale = new Vector3(1, 1, 1);
            healthBar = true;
        }
        else if (enemyPosition.x > direction)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
   void MoveInDierection(float _direction)
    {
        animator.SetBool("Run", false);

        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            idleTimer = 0;
            direction = _direction;
        }
    }
}