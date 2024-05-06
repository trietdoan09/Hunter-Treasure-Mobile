using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class UIData
{

    public int gold;
    public int crystal;
    public List<Item> inventory = new List<Item>();
    public UIData(InventoryManager inventoryManager)
    {
        gold = inventoryManager.gold;
    }
}
