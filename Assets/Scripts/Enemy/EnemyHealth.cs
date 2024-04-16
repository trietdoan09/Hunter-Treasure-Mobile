using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    Animator animator;

    public GameObject enemySpawn;
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

                GetComponent<EnemyHealth>().enabled = false;
                GetComponent<EnemyAI>().enabled = false;
                GetComponent<EnemyAttack>().enabled = false;

                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Collider2D>().enabled = false;

                playerManager.GetComponent<PlayerManager>().PlayerTakeExp(giveExp);

                var item = Instantiate(theDrop[Random.Range(0, theDrop.Length)]);
                item.transform .position = gameObject.transform.position;

                Invoke(nameof(Deactivate), 5);
            }
        }
    }

    public void SpawnEnemy()
    {
        dead = false;
        health = maxHealth;

        animator.SetTrigger("Dead");
        enemySpawn.SetActive(true);
        
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Collider2D>().enabled = true;

        Invoke(nameof(DeplaySpawn), 2);
    }

    void DeplaySpawn()
    {
        GetComponent<EnemyAI>().enabled = true;
        GetComponent<EnemyHealth>().enabled = true;
        GetComponent<EnemyAttack>().enabled = true;
    }
    public void EnemyTakeDamage(int damage)
    {
        int dameTaken = damage - def;
        health -= dameTaken > 0 ? damage : 0;
        heathSlider.value = health;
    }

    private void Deactivate()
    {
        enemySpawn.SetActive(false);
    }
}
