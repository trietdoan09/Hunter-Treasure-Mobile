using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
     ItemTest itemTest;

    public void RemoveItem()
    {
        InventoryManagerTest.instance.Remove(itemTest);
        Destroy(gameObject);
    }

    public void AddItem(ItemTest newItem)
    {
        itemTest = newItem;
    }
}
