using UnityEngine;

public class AddItem : MonoBehaviour
{
    InventoryManager inventoryManager;
    NotificationItem notificationItem;

    public Item item;
    public int countItem;

    public GameObject addItemObj;
    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        notificationItem = FindAnyObjectByType<NotificationItem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventoryManager.AddItem(item,countItem);
            inventoryManager.SpawnItem();

            notificationItem.NotificationItems(item, countItem);

            Destroy(gameObject);
        }
    }
   
}
