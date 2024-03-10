using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Item item;
    InventoryManager inventoryManager;

    [Header("Shop")]
     int productprice;
     int totalPrice;
    public TextMeshProUGUI productpriceText;

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

    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();

        productprice = item.productprice;
        productpriceText.text = productprice.ToString();

    }

    public void Notification()
    {
        SetQuantity();

        if (inventoryManager.gold >= productprice)
        {

            notification.SetActive(true);
            description.SetActive(false);
            imageShop.sprite = item.image;

            var quantityMaxs = inventoryManager.gold / productprice;
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
            //Instantiate(notGoldTxt,transform);
            notGoldTxt.SetActive(true);
        }

    }

    public void Description()
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
    public void SetQuantity()
    {
        quantitySlider.value = 1;
        quantity = Mathf.FloorToInt(quantitySlider.value);
        totalPrice = quantity * productprice;

        quantityText.text = quantitySlider.value.ToString();
        totalPriceText.text = totalPrice.ToString();
    }

    public void Buy()
    {
        
        InventoryManager inventoryManager = FindAnyObjectByType<InventoryManager>();
        inventoryManager.AddItem(item, quantity);
        inventoryManager.gold = inventoryManager.gold - totalPrice;
        inventoryManager.GoldText(inventoryManager.gold);

        NPCShop nPCShop = FindAnyObjectByType<NPCShop>();
        nPCShop.GoldText(inventoryManager.gold);

        notification.SetActive(false);
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
