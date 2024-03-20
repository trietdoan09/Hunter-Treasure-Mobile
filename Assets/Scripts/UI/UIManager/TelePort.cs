using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort : MonoBehaviour
{
    LoadScene loadScene;

    private void Start()
    {
        loadScene = FindAnyObjectByType<LoadScene>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            loadScene.notificationLoadscene.SetActive(true);
        }
    }
}
