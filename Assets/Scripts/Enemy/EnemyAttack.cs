//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyAttack : MonoBehaviour
//{
//    [Header("Attack Parameters")]
//    [SerializeField]  float attackCooldown;
//    [SerializeField]  float range;
//    [SerializeField]  int damage;

//    [Header("Collider Parameters")]
//    [SerializeField]  float colliderDistance;/**/
//    [SerializeField]  BoxCollider2D boxCollider;

//    [Header("Player Layer")]
//    [SerializeField]  LayerMask playerLayer;
//     float cooldownTimer = Mathf.Infinity;

//     Animator anim;
//    //[Header("Attack Sound")]
//    //[SerializeField] private AudioClip attackSound;

//     PlayerHealth playerhealth;



//    private void Awake()
//    {
//        anim = GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        cooldownTimer += Time.deltaTime;

//        if (PlayerInSight())
//        {
//            if (cooldownTimer >= attackCooldown && playerhealth.health > 0)
//            {
//                cooldownTimer = 0;
//                anim.SetTrigger("Attack");

//            }
//        }
//    }
//    private bool PlayerInSight()
//    {
//        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + colliderDistance * range * transform.localScale.x * transform.right,
//            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
//            0, Vector2.left, 0, playerLayer);

//        if (hit.collider != null)
//            playerhealth = hit.transform.GetComponent<PlayerHealth>();
//        return hit.collider != null;
//    }
//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireCube(boxCollider.bounds.center + colliderDistance * range * transform.localScale.x * transform.right,
//            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
//    }

//    public void DamagePlayer()
//    {
//        if (PlayerInSight())

//            playerhealth.TakeDamage(damage);

//    }

//}
