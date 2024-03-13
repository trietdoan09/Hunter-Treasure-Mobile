using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIData
{

    public int gold;
    public int crystal;

    public List<InventoryItem> inventoryItems;


    public UIData(InventoryManager inventoryManager)
    {
        gold = inventoryManager.gold;
        //inventoryItems = inventoryManager.inventoryItems;

    }
}
