﻿using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager : MonoBehaviour
{

    UseItem useItems;
    public static InventoryManager instance;

    public Item[] startItem;

    public int maxStackedItems;
    public GameObject InventoryItemPrefab;
    public Transform InventoryItemTransform;
    public List<Item> inventoryItems = new List<Item>();

    public GameObject descriptionObj;
    public GameObject useItemObj;

    public int gold;
    public TextMeshProUGUI goldText;

    [Header("Description")]

    [HideInInspector] public string itemName;
    [HideInInspector] public string level;
    [HideInInspector] public string types;
    [HideInInspector] public string description;
    [HideInInspector] public bool useItem;


    public Image images;
    public TextMeshProUGUI itemNameTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI typesTxt;
    public TextMeshProUGUI descriptionTxt;

    private void Start()
    {
        //foreach (var item in startItem)
        //{
        //    AddItem(item, item.countItem);
        //}
        useItems = FindAnyObjectByType<UseItem>();
        descriptionObj.SetActive(false);
        useItemObj.SetActive(false);

        GoldText(gold);
    }
    private void Awake()
    {
        instance = this;
    }
    public void GoldText(int gold)
    {
        goldText.text = gold.ToString();
    }

    public void SaveInvetory()
    {
        SaveSystem.SaveInventory(instance);
        Debug.Log(gold + "gold");
        
    }
    public void LoadInventory()
    {
        UIData uida = SaveSystem.LoadInventory();

        gold = uida.gold;
        
        GoldText(gold);
        Debug.Log(gold + "gold load");
    }

    //public bool AddItem(Item item, int countItem)
    //{
    //    for (int i = 0; i < InventoryItemTransform.childCount; i++)
    //    {

    //        var slott = InventoryItemTransform.GetChild(i);
    //        InventoryItem itemInSlot = slott.GetComponent<InventoryItem>();

    //        if (itemInSlot.item == item
    //            && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
    //        {
    //            itemInSlot.count += countItem;
    //            itemInSlot.ReFreshCount();

    //            if (itemInSlot.count > maxStackedItems)
    //            {
    //                var totalCount = itemInSlot.count - maxStackedItems;
    //                itemInSlot.count = maxStackedItems;
    //                itemInSlot.ReFreshCount();
    //                SpawnNewItem(item, totalCount);
    //            }
    //            return true;
    //        }
    //    }

    //    for (int i = 0; i < InventoryItemTransform.childCount; i++)
    //    {
    //        var slott = InventoryItemTransform.GetChild(i);
    //        InventoryItem itemInSlot = slott.GetComponent<InventoryItem>();

    //        if (itemInSlot.item != item )
    //        {
    //            SpawnNewItem(item, countItem);
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //public void SpawnNewItem(Item item, int countItem)
    // {

    //     GameObject newItemGo = Instantiate(InventoryItemPrefab, InventoryItemTransform);
    //     InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
    //     //inventoryItem.InitialiseItem(item, countItem);
    // }

    public void AddItem(Item item, int count)
    {
        var check = inventoryItems.Any(i => i.itemName == item.itemName
        && i.stackable == true && i.quantity < maxStackedItems);

        if (check)
        {
            item.quantity += count;
            Debug.Log(item.quantity + " da co");

            if (item.quantity > maxStackedItems)
            {
                var totalCount = item.quantity - maxStackedItems;
                item.quantity = maxStackedItems;

                inventoryItems.Add(item);
                item.quantity = totalCount;

                Debug.Log(item.quantity + " count nhieu");

            }

        }
        else
        {
            inventoryItems.Add(item);
            item.quantity = count;
            Debug.Log(item.quantity + " k co");

        }

    }

    public void SpawnItem()
    {
        foreach(Transform item in InventoryItemTransform)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in inventoryItems)
        {
            GameObject newItem = Instantiate(InventoryItemPrefab, InventoryItemTransform);
            InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
            inventoryItem.InitialiseItem(item);

        }
    }
    public void ItemSelect()
    {
        for (int i = 0; i < InventoryItemTransform.childCount; i++)
        {
            var slott = InventoryItemTransform.GetChild(i);
            InventoryItem itemInSlot = slott.GetComponent<InventoryItem>();
            itemInSlot.image.color = Color.white;
            itemInSlot.thisUseItem = false;

        }
    }

    public void UseItem()
    {
        for (int i = 0; i < InventoryItemTransform.childCount; i++)
        {
            var slott = InventoryItemTransform.GetChild(i);
            InventoryItem itemInSlot = slott.GetComponent<InventoryItem>();

            if (itemInSlot.thisUseItem == true)
            {
                // sử dụng vật phẩm
                Use(itemInSlot);
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                    descriptionObj.SetActive(false);
                    //useItemObj.SetActive(false);
                }
                else
                {
                    itemInSlot.ReFreshCount();
                }
            }

        }
    }

    public void Description()
    {
        for (int i = 0; i < InventoryItemTransform.childCount; i++)
        {
            var slott = InventoryItemTransform.GetChild(i);
            InventoryItem InventoryItem = slott.GetComponent<InventoryItem>();

            descriptionObj.SetActive(true);
            if(InventoryItem.thisUseItem == true)
            {
                images.sprite = InventoryItem.image.sprite;
                itemNameTxt.text = InventoryItem.itemName.ToString();
                levelTxt.text = "Level: " + InventoryItem.level.ToString();
                typesTxt.text = InventoryItem.types.ToString();
                descriptionTxt.text = InventoryItem.description.ToString();

                if (InventoryItem.useItem == true)
                {
                    useItemObj.SetActive(true);
                }
                else
                {
                    useItemObj.SetActive(false);
                }
            }
        }
    }

    public void Use(InventoryItem inventoryItem )
    {
        switch(inventoryItem.itemName)
        {
            case "HP":
                useItems.HP(inventoryItem.value);
                break;

            case "MP":
                useItems.MP(inventoryItem.value);
                break;

            case "ATK":
                useItems.ATK(inventoryItem.value, inventoryItem.timer );
                break;

            case "DEF":
                useItems.DEF(inventoryItem.value, inventoryItem.timer);
                break;
        }
    }
   
}
