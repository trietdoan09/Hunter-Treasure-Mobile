using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int gold;

    public TextMeshProUGUI goldText;

    InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();

        gold = inventoryManager.gold;
        goldText.text = gold.ToString();
    }

   
    void Update()
    {
       
    }
}
