using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider heathSlider;
    public float health;
    public float maxHealth;
    public int def;
    bool dead;
    public GameObject[] theDrop;

    Animator animator;
    void Start()
    {

        animator = GetComponent<Animator>();
        health = maxHealth;
        heathSlider.maxValue = maxHealth;
        heathSlider.value = maxHealth;
        dead = false;
    }

    public void Respawn()
    {
        health = maxHealth;
        animator.ResetTrigger("Dead");

        dead = false;

    }

    private void Update()
    {


        if (health <= 0)
        {
            if (!dead)
            {
                animator.SetTrigger("Dead");
                if (GetComponent<EnemyHealth>() != null)
                    GetComponent<EnemyHealth>().enabled = false;
                if (GetComponent<EnemyAI>() != null)
                    GetComponent<EnemyAI>().enabled = false;
                dead = true;

                var one = Instantiate(theDrop[Random.Range(0, theDrop.Length)]);
                one.transform.position = gameObject.transform.position;

                Destroy(gameObject, 5);
            }

        }
    }
   /* public void TakeDamage(int damage)
    {

        health -= DamagePlayer.TakeDamge(damage, def);
        heathSlider.value = health;
    }*/
    
}
