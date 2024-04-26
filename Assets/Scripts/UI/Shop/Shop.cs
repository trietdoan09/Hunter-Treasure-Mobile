using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    ShopManager shopManager;

    public Item item;
    public ItemShop itemShop;

    public int productprice;
    public TextMeshProUGUI productpriceText;

    public bool check;


    private void Start()
    {
        shopManager = FindAnyObjectByType<ShopManager>();
        productpriceText.text = item.productprice.ToString();
    }


    public void Description()
    {
        shopManager.Description(itemShop);
    }

    public void Notification()
    {
        shopManager.Notification(itemShop);
    }

    public void Click()
    {
        shopManager.Check();
        check = true;
    }

    public void Buy()
    {
        shopManager.Buy();
    }
}
