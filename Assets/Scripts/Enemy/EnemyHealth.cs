using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    Animator animator;
    Collider2D collider2D;
    Rigidbody2D rigidbody2D;
    public Slider heathSlider;
    public float maxHealth;
    public int def;
    public bool dead;
    public float health;
   
    public GameObject[] theDrop;

    private GameObject playerManager;
    [SerializeField] private int level;
    [SerializeField] private int giveExp;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerManager = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
        heathSlider.maxValue = maxHealth;
        heathSlider.value = maxHealth;
        dead = false;
        level = Random.Range(1, 11);
        giveExp = 20 * level;
    }


    private void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= 0)
        {
            if (!dead)
            {
                dead = true;
                animator.SetTrigger("Dead");

                if (GetComponent<EnemyHealth>() != null)
                    //GetComponent<EnemyHealth>().enabled = false;
                if (GetComponent<EnemyAI>() != null)
                    GetComponent<EnemyAI>().enabled = false;
                if (GetComponent<EnemyAttack>() != null)
                    GetComponent<EnemyAttack>().enabled = false;
                rigidbody2D.gravityScale = 0;
                collider2D.enabled = false;
                playerManager.GetComponent<PlayerManager>().PlayerTakeExp(giveExp);

                var item = Instantiate(theDrop[Random.Range(0, theDrop.Length)]);
                item.transform .position = gameObject.transform.position;

                Destroy(gameObject, 5);
            }
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        int dameTaken = damage - def;
        health -= damage > 0 ? damage : 0;
        heathSlider.value = health;
    }
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
