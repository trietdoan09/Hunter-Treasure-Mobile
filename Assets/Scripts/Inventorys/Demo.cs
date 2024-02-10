using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemToPickUp;

    public void PickUpItem(int id)
    {
        bool result = inventoryManager.AddItem(itemToPickUp[id]);
        if (result == true)
        {
        }
        else
        {

        }
    }

    public void GetSelectItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("receivedItem: " + receivedItem);
        }
        else 
        {
            Debug.Log("No item received!");
        }
    }

    public void UseGetSelectItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Used: " + receivedItem);
        }
        else
        {
            Debug.Log("No item Used");
        }
    }
}
