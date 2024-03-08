using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{
    public static Tests  instance;
    public int gold;

    InventoryManager inventory;
    void Start()
    {
        
     inventory = FindAnyObjectByType<InventoryManager>();   
        gold = inventory.gold;
    }
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("a");

            inventory.gold += 1500;
            //SaveSystem.SaveGold(inventory);
        }
        if (Input.GetMouseButtonDown(0))
        {
            //SaveSystem.LoadGold();
            Debug.Log(inventory.gold);
        }
    }
}
