using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillEnemyRange : MonoBehaviour
{
    public float speed;
    public int damage;

    Animator animator;
    BoxCollider2D boxCollider;
    PlayerManager playerManager;
    EnemyController enemyController;

    Transform playerMovement;

    [Header("Txt dame ")]
    [SerializeField] GameObject damageObj;
    [SerializeField] TextMeshPro damageTxt;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerManager = FindAnyObjectByType<PlayerManager>();
        enemyController = FindAnyObjectByType<EnemyController>();
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
            AudioManager.instance.PlaySFX("EnemyAttack");

            boxCollider.enabled = false;
            animator.SetTrigger("Explosion");
           var damages = damage * enemyController.enemyLevel;

            playerManager.PlayerTakeDame(damages);
            damageTxt.text = "-" + playerManager.damagaTaken.ToString();

            Instantiate(damageObj, playerManager.transform);
        }
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
