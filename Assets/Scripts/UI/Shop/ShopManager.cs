using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Item item;
    GameController gameController;

    [Header("Shop")]
    public int gold;
    public int productprice;
    public TextMeshProUGUI productpriceText;

    public Image imageShop;

    [Header("Notification")]
    public GameObject notification;
    public Slider quantitySlider;

    public int quantityMin;
    public int quantityMax;
    
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
        gameController = FindAnyObjectByType<GameController>();
        gold = gameController.gold;

        productprice = item.productprice;
        productpriceText.text = productprice.ToString();

        quantityMax = gold / productprice;
        quantitySlider.maxValue = quantityMax;

        quantitySlider.value = quantityMin = 1;
        quantityText.text = quantityMin.ToString();

        totalPriceText.text = productprice.ToString();
    }

    private void Update()
    {
        quantityText.text = quantitySlider.value.ToString();
        Debug.Log(quantitySlider.value);
        var totalPrice = quantitySlider.value * productprice;
        Debug.Log(totalPrice);

        totalPriceText.text = totalPrice.ToString();

    }

    public void Notification()
    {
        notification.SetActive(true);
        imageShop.sprite = item.image;
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

    public void Buy()
    {
        InventoryManager inventoryManager = FindAnyObjectByType<InventoryManager>();
        inventoryManager.AddItem(item);
        notification.SetActive(false);
    }
}
