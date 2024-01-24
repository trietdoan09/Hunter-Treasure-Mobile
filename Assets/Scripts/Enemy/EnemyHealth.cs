using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Slider heathSlider;
    [SerializeField] float maxHealth;
    [SerializeField] int def;
    public bool dead;
    public float health;
   

    [SerializeField] GameObject[] theDrop;
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
        gameObject.SetActive(true);
        health = maxHealth;
        heathSlider.value = health;

        if (GetComponent<EnemyHealth>() != null)
           GetComponent<EnemyHealth>().enabled = true;
        if (GetComponent<EnemyAI>() != null)
            GetComponent<EnemyAI>().enabled = true;

        animator.ResetTrigger("Dead");

        dead = false;

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            health -= 20;
            heathSlider.value = health;
        }

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

                //var one = Instantiate(theDrop[Random.Range(0, theDrop.Length)]);
                //one.transform.position = gameObject.transform.position;

                
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
