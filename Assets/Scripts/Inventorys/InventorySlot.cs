using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public Image image;
    public Color selectedcolor, notSelectedcolor;

    public bool thisItemSelected;

    public GameObject descriptionObj;
    public GameObject useItemObj;
    public Image images;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI level;
    public TextMeshProUGUI types;
    public TextMeshProUGUI description;


    private void Start()
    {
        descriptionObj.SetActive(false);
        useItemObj.SetActive(false);
    }

    private void Awake()
    {
        DeSelect();
    }

    public void Select()
    {
        image.color = selectedcolor;
    }

    public void DeSelect()
    {
        image.color = notSelectedcolor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
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
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
       

        descriptionObj.SetActive(true);
        Description();
    }

    public void Description()
    {
        InventoryItem itemInSlot = GetComponentInChildren<InventoryItem>();
        itemInSlot.image.color = Color.red;
        thisItemSelected = true;
        
        for (int i = 0; i <= itemInSlot.count; i++)
        {
        itemInSlot.image.color = Color.white;
        }

        images.sprite = itemInSlot.image.sprite;
        itemName.text = itemInSlot.itemName.ToString();
        level.text = "Level: " + itemInSlot.level.ToString();
        types.text = itemInSlot.types.ToString();
        description.text = itemInSlot.description.ToString();

        if(itemInSlot.useItem == true)
        {
            useItemObj.SetActive(true);
        }
        else
        {
            useItemObj.SetActive(false);
        }

    }
    public void OnRightClick()
    {

    }
}
