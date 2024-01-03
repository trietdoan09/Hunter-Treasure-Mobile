using System.Text.RegularExpressions;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float right, left, direction;
    public float distanceMovement;

    EnemyMovement enemyMovement;
    private void Start()
    {
        enemyMovement = FindAnyObjectByType<EnemyMovement>();

        var currentPosition = transform.position;
         right = currentPosition.x + distanceMovement;
         left = currentPosition.x - distanceMovement;
         direction = right;
    }

    private void Update()
    {
        var playerPosition = target.transform.position;
        var enemyPosition = transform.position;

       /* if (playerPosition.x > left && playerPosition.x < right)
        {
            transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, speed * Time.deltaTime);
        }*/
        if (enemyMovement.PlayerInSight())
        {
            transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, speed * Time.deltaTime);
        }
        else
        {
            if(enemyPosition.x >= right )
            {
                direction = left;
            }
            else if(enemyPosition.x <= left )
            {
                direction = right;
            }
            transform.position = Vector3.MoveTowards(enemyPosition,new Vector3(direction, enemyPosition.y,0),speed *Time.deltaTime);
        }
    }

}