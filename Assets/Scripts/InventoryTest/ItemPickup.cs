using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public ItemTest ItemTest;

    void PickUp()
    {
        InventoryManagerTest.instance.Add(ItemTest);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
