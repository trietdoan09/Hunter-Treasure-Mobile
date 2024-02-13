using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{
    public Item[] startItem;

    public int maxStackedItems;
    public InventorySlot[] inventorySlots;
    public GameObject InventoryItemPrefab;

    InventorySlot inventorySlot;

    private void Start()
    {
        inventorySlot = FindAnyObjectByType<InventorySlot>();
        foreach (var item in startItem)
        {
            AddItem(item);
        }
    }


    public bool AddItem(Item item)
    {
        // kiểm tra xem có cùng item , số lượng thấp hơn max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item
                && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.ReFreshCount();
                return true;
            }
        }

        // tìm chổ trống
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public void ItemSelect()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].image.color = Color.white;
            inventorySlots[i].thisUseItem = false;
        }
    }

    public void UseItem()
    {
        for(int i = 0;i < inventorySlots.Length;i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            
            if(slot.thisUseItem == true)
            {
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                    slot.descriptionObj.SetActive(false);
                }
                else
                {
                    itemInSlot.ReFreshCount();
                }
            }
                
        }
    }
}
