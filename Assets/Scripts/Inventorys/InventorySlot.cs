using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public Image image;

    public GameObject descriptionObj;
    public GameObject useItemObj;
    public Image images;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI level;
    public TextMeshProUGUI types;
    public TextMeshProUGUI description;

    public bool thisUseItem;

    InventoryManager inventoryManager;
    InventoryItem itemInSlot;

    private void Start()
    {
        descriptionObj.SetActive(false);
        useItemObj.SetActive(false);
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        itemInSlot = GetComponentInChildren<InventoryItem>();
    }
  
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            itemInSlot = eventData.pointerDrag.GetComponent<InventoryItem>();
            itemInSlot.parentAfterDrag = transform;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
        }
    }

    public void OnLeftClick()
    {
        OnSlot();
        if(itemInSlot != null)
        {
            Description();
        }
       else
        {
            descriptionObj.SetActive(false);
            useItemObj.SetActive(false);

        }
    }

    public void OnSlot()
    {
        inventoryManager.ItemSelect();
        thisUseItem = true;
        image.color = Color.red;
    }
    public void Description()
    {
        descriptionObj.SetActive(true);

        images.sprite = itemInSlot.image.sprite;
        itemName.text = itemInSlot.itemName.ToString();
        level.text = "Level: " + itemInSlot.level.ToString();
        types.text = itemInSlot.types.ToString();
        description.text = itemInSlot.description.ToString();

        if (itemInSlot.useItem == true)
        {
            useItemObj.SetActive(true);
        }
        else
        {
            useItemObj.SetActive(false);
        }
    }
}
