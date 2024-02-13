using UnityEngine;

public class AddItem : MonoBehaviour
{
    public Item item;
     InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventoryManager.AddItem(item);
            Destroy(gameObject);
        }
    }
}
