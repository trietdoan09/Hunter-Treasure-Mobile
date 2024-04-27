using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseHPMP : MonoBehaviour
{
    InventoryManager inventoryManager;
    UseItem useItem;

    public TextMeshProUGUI HPTxt;
    public TextMeshProUGUI MPTxt;

    public GameObject panel;

    void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
        useItem = FindAnyObjectByType<UseItem>();

        HPTxt.text = 0.ToString();
        MPTxt.text = 0.ToString();

        for (int i = 0; i < inventoryManager.inventoryItems.Count; i++)
        {
            var item = inventoryManager.inventoryItems[i];

            if("HP" == item.itemName)
            {
                HPTxt.text = item.quantity.ToString();

            }
            if ("MP" == item.itemName)
            {
                MPTxt.text = item.quantity.ToString();

            }
        }
    }

   public void HP()
    {
        for (int i = 0; i < inventoryManager.inventoryItems.Count; i++)
        {
            var item = inventoryManager.inventoryItems[i];
            if("HP" == item.itemName)
            {
                
                if (item.quantity > 0)
                {
                    useItem.HP(item.value, item.quantity);
                    item.quantity--;

                    HPTxt.text = item.quantity.ToString();
                }

                if (item.quantity <= 0)
                {
                    Instantiate(panel);
                    inventoryManager.inventoryItems.Remove(item);

                }
            }
        }
    }

    public void MP()
    {
        for (int i = 0; i < inventoryManager.inventoryItems.Count; i++)
        {
            var item = inventoryManager.inventoryItems[i];
            if ("MP" == item.itemName)
            {
                if(item.quantity > 0)
                {
                    useItem.MP(item.value, item.quantity);
                    item.quantity--;
                    MPTxt.text = item.quantity.ToString();

                }

                if (item.quantity < 0)
                {
                    Instantiate(panel);
                    inventoryManager.inventoryItems.Remove(item);

                }
            }
        }
    }
}
