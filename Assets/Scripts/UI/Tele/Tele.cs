using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tele : MonoBehaviour
{
    public GameObject teleName;

    public Button jungleButton, desertButton, dungeonButton;

    void Start()
    {
        teleName.SetActive(false);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            teleName.SetActive(true);
        }
    }

    public void LoadScenes()
    {

    }
}
