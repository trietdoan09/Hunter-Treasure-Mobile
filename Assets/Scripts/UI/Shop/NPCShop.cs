using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCShop : MonoBehaviour
{
    public GameObject shop;
    public TextMeshProUGUI goldText;
    InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            shop.SetActive(true);
            Gold(inventoryManager.gold);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shop.SetActive(false);
        }
    }

    public void Gold(int gold)
    {
        goldText.text = gold.ToString();
    }
}
