using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerTest : MonoBehaviour
{
    public static InventoryManagerTest instance;
    public List<ItemTest> items = new List<ItemTest>();

    public Transform itemContent;
    public GameObject inventoryItem;

    public Toggle enableRemove;
    InventoryItemController[] inventoryItems;

    public void Awake()
    {
        instance = this;
    }

    public void Add(ItemTest item)
    {
        items.Add(item);
    }

    public void Remove(ItemTest item)
    {
        items.Remove(item);
    }

    public void ListItem()
    {
        foreach(Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var id = obj.transform.Find("Counts").GetComponent<TextMeshProUGUI>();
            var icon = obj.transform.Find("ItemImage").GetComponent<Image>();

            id.text = item.id.ToString();
            icon.sprite = item.icon;
        }

        SetInventoryItems();
    }
    public void OffToggle()
    {
        enableRemove.isOn = false;
    }

    public void EnableItemRemove()
    {
        if(enableRemove.isOn)
        {
            foreach(Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        inventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();

        for(int i = 0; i < items.Count; i++)
        {
            inventoryItems[i].AddItem(items[i]);
        }
    }
}
