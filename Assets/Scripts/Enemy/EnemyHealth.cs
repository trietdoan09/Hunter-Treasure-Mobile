using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    Enemy enemy;
    void Start()
    {
        enemy = FindAnyObjectByType<Enemy>();

        animator = GetComponent<Animator>();
        health = maxHealth;
        heathSlider.maxValue = maxHealth;
        heathSlider.value = maxHealth;
        dead = false;
        StartCoroutine(AddHealth());
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

        if (health > maxHealth)
        {
            health = maxHealth;

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
    IEnumerator AddHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (enemy.check == false && health < maxHealth)
            {
                health += 10;
                heathSlider.value = health;
            }
            if(health >= maxHealth)
                StopCoroutine(AddHealth());
            yield return null;
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
