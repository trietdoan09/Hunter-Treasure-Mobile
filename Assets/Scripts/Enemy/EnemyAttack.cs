using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] float attackCooldown;
    [SerializeField] float range;
    [SerializeField] int damage;

    [Header("Enemy Range")]
    public GameObject skill;
    public Transform targetPosition;

    [Header("Collider Parameters")]
    [SerializeField] float colliderDistance;
    [SerializeField] BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] LayerMask playerLayer;
    float cooldownTimer = Mathf.Infinity;

    Animator anim;
    //[Header("Attack Sound")]
    //[SerializeField] private AudioClip attackSound;

    PlayerManager playerManager;



    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        playerManager = FindAnyObjectByType<PlayerManager>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown && playerManager.playerCurrentHealPoint > 0)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");

            }
        }
    }
    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + colliderDistance * range * transform.localScale.x * transform.right,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerManager = hit.transform.GetComponent<PlayerManager>();
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + colliderDistance * range * transform.localScale.x * transform.right,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void DamagePlayer()
    {
        if (PlayerInSight())

            playerManager.PlayerTakeDame(damage);
    }

    public void DamageRange()
    {
        Instantiate(skill, targetPosition);
    }
}
