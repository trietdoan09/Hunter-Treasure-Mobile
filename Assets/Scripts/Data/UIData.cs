using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class UIData
{

    public int gold;
    public int crystal;

    public UIData(InventoryManager inventoryManager)
    {
        gold = inventoryManager.gold;

    }
}
