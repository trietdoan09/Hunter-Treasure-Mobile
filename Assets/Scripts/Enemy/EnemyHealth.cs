using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider heathSlider;
    public float maxHealth;
    public int def;
    public bool dead;
    public float health;
   
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


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            health -= 20;
            heathSlider.value = health;
        }

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
                    GetComponent<EnemyHealth>().enabled = false;
                if (GetComponent<EnemyAI>() != null)
                    GetComponent<EnemyAI>().enabled = false;
                if (GetComponent<EnemyAttack>() != null)
                    GetComponent<EnemyAttack>().enabled = false;
                

                var item = Instantiate(theDrop[Random.Range(0, theDrop.Length)]);
                item.transform .position = gameObject.transform.position;

                Destroy(gameObject, 5);
            }
        }
    }

    
  
    //public void TakeDamage(int damage)
    //{

    //    health -= DamagePlayer.TakeDamge(damage, def);
    //    heathSlider.value = health;
    //}
    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
