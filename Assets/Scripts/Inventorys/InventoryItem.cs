using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour
{

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count;
    [HideInInspector] public Transform parentAfterDrag;


    [HideInInspector] public string itemName;
    [HideInInspector] public string level;
    [HideInInspector] public string types;
    [HideInInspector] public string description;
    [HideInInspector] public bool useItem;


    public bool thisUseItem;

    InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    public void InitialiseItem(Item newItem )
    {
        item = newItem;
        image.sprite = newItem.image;

        itemName = newItem.itemName;
        level = newItem.level;
        types = newItem.types;
        description = newItem.description;
        useItem = newItem.useItem;

        count = newItem.quantity;


        ReFreshCount();
    }

    public void ReFreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

   
    public void OnMouseDown()
    {
        inventoryManager.ItemSelect();
        thisUseItem = true;
        image.color = Color.red;

       inventoryManager.Description();
    }
}
