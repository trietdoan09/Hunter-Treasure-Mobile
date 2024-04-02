using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnemyRange : MonoBehaviour
{
    public float speed;
    public int damage;

    Animator animator;
    BoxCollider2D boxCollider;

    Transform playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>().transform;

        var playerPosition = playerMovement.transform.position;
        var skillPosition = transform.position;

        var direction = (playerPosition - skillPosition).normalized;
        var movement = speed * direction * Time.deltaTime;
        transform.Translate(movement);

        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxCollider.enabled = false;
            animator.SetTrigger("Explosion");
        }
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
