using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using static Cinemachine.DocumentationSortingAttribute;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Item[] startItem;

    public int maxStackedItems;
    public GameObject InventoryItemPrefab;
    public Transform InventoryItemTransform;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

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
        foreach (var item in startItem)
        {
            AddItem(item, item.countItem);
        }
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

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        SaveSystem.SaveInventory(instance);
    //        Debug.Log(gold + "gold");

    //        SaveSystem.LoadInventory();
    //        Debug.Log(gold);
    //    }
    //}

    public bool AddItem(Item item, int countItem)
    {
        for (int i = 0; i < InventoryItemTransform.childCount; i++)
        {

            var slott = InventoryItemTransform.GetChild(i);
            InventoryItem itemInSlot = slott.GetComponent<InventoryItem>();

            if (itemInSlot.item == item
                && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable == true)
            {
                itemInSlot.count += countItem;
                itemInSlot.ReFreshCount();
                inventoryItems.Add(itemInSlot);

                if (itemInSlot.count > maxStackedItems)
                {
                    var totalCount = itemInSlot.count - maxStackedItems;
                    itemInSlot.count = maxStackedItems;
                    itemInSlot.ReFreshCount();
                    SpawnNewItem(item, totalCount);
                }
                return true;
            }
        }

        for (int i = 0; i < InventoryItemTransform.childCount; i++)
        {
            var slott = InventoryItemTransform.GetChild(i);
            InventoryItem itemInSlot = slott.GetComponent<InventoryItem>();

            if (itemInSlot.item != item )
            {
                SpawnNewItem(item, countItem);
                return true;
            }
        }
        return false;
    }

   public void SpawnNewItem(Item item, int countItem)
    {

        GameObject newItemGo = Instantiate(InventoryItemPrefab, InventoryItemTransform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item, countItem);
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
                itemInSlot.count--;
                if (itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                    descriptionObj.SetActive(false);
                    useItemObj.SetActive(false);
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
}
