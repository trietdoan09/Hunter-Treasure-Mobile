using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("a");

        //    inventory.gold += 1500;
        //    //SaveSystem.SaveGold(inventory);
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //SaveSystem.LoadGold();
        //    Debug.Log(inventory.gold);
        //}
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene(1);
    }
}
