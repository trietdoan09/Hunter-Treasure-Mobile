using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public float range;
    public float colliderDistance;
    public LayerMask playerLayer;
    //public Transform playerPosition;


    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public bool PlayerInSight()
    {
        RaycastHit2D distancePlayer = Physics2D.BoxCast(boxCollider.bounds.center + colliderDistance * range * transform.localScale.x * transform.right,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

       // if (distancePlayer.collider != null)
           // playerPosition = distancePlayer.transform.GetComponent<PlayerHealth>();

        return distancePlayer.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider.bounds.center + colliderDistance * range * transform.localScale.x * transform.right,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
