using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    InventoryManager inventoryManager;
    Shop shop;

    public GameObject[] itemShopPrefab;
    public Transform shopContent;

    [Header("Shop")]
    public int productprice;
     int totalPrice;
    

    public Image imageShop;

    [Header("Notification")]
    public GameObject notification;
    public Slider quantitySlider;
    public GameObject notGoldTxt;

    public int quantityMax;
    int quantity;


    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI totalPriceText;


    [Header("Description")]
    public GameObject description;

    public Image images;
    public TextMeshProUGUI itemNameTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI typesTxt;
    public TextMeshProUGUI descriptionTxt;

    private void Awake()
    {
        foreach(var item in itemShopPrefab)
        {
            Instantiate(item,shopContent);
        }

    }
    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        shop = FindAnyObjectByType<Shop>();

    }

    public void Notification(ItemShop item)
    {
        SetQuantity(item);

        if (inventoryManager.gold >= item.productprice)
        {
            quantity = item.quantity;
            productprice = item.productprice;
            //totalPrice = item.productprice * quantity;

            notification.SetActive(true);
            description.SetActive(false);
            imageShop.sprite = item.image;

            var quantityMaxs = inventoryManager.gold / item.productprice;
            if (quantityMaxs <= quantityMax)
            {
                quantitySlider.maxValue = quantityMaxs;
            }
            else
            {
                quantitySlider.maxValue = quantityMax;
            }
        }

        else
        {
            Instantiate(notGoldTxt, transform);
            //notGoldTxt.SetActive(true);
        }

    }

    public void Description(ItemShop item)
    {
        description.SetActive(true);

        images.sprite = item.image;
        itemNameTxt.text = item.itemName.ToString();
        levelTxt.text = "Level: " + item.level.ToString();
        typesTxt.text = item.types.ToString();
        descriptionTxt.text = item.description.ToString();
    }

    public void QuantitySlider()
    {
        quantityText.text = quantitySlider.value.ToString();
        quantity = Mathf.FloorToInt(quantitySlider.value);

        totalPrice = quantity * productprice;
        totalPriceText.text = totalPrice.ToString();
    }
    public void SetQuantity(ItemShop itemShop)
    {
        quantitySlider.value = 1;
        quantity = Mathf.FloorToInt(quantitySlider.value);
        totalPrice = quantity * itemShop.productprice;

        quantityText.text = quantitySlider.value.ToString();
        totalPriceText.text = totalPrice.ToString();
    }

    public void Buy()
    {
        

        for(int i = 0; i < shopContent.childCount; i++)
        {
            var shopItem = shopContent.GetChild(i);
            Shop shop = shopItem.GetComponent<Shop>();

            if(shop.check == true)
            {
                InventoryManager inventoryManager = FindAnyObjectByType<InventoryManager>();
                inventoryManager.AddItem(shop.item, quantity);
                inventoryManager.SpawnItem();

                inventoryManager.gold = inventoryManager.gold - totalPrice;
                inventoryManager.GoldText(inventoryManager.gold);

                NPCShop nPCShop = FindAnyObjectByType<NPCShop>();
                nPCShop.GoldText(inventoryManager.gold);

                notification.SetActive(false);
            }
        }
    }

    public void Check()
    {
        for (int i = 0;i < shopContent.childCount;i++)
        {
            var shopItem = shopContent.GetChild(i);
            Shop shop = shopItem.GetComponent<Shop>();

            shop.check = false;
        }
    }

}
