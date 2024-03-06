using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int def = 20;



    void Start()
    {
    }

    public void TakeDamage(int damage)
    {
        health -= damage - def;
    }
}
