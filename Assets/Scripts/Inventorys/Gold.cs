using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    InventoryManager inventoryManager;
    NotificationItem notificationItem;
    public Item item;

    public int gold;
    public int goldMin;
    public int goldMax;

    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        notificationItem = FindAnyObjectByType<NotificationItem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gold = Random.Range(goldMin, goldMax);
            inventoryManager.gold = inventoryManager.gold + gold;
            inventoryManager.GoldText(inventoryManager.gold);

            notificationItem.NotificationItems(item, gold);

            Destroy(gameObject);
        }
    }
}
