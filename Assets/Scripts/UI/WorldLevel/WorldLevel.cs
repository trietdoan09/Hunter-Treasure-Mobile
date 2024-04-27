using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldLevel : MonoBehaviour
{
    PlayerManager playerManager;
    InventoryManager inventoryManager;

    public int worldLevel = 1;
    public TextMeshProUGUI worldLevelTxt;

     int levelPlayer;
     int levelUp;
    public TextMeshProUGUI levelPlayerTxt;

    public GameObject levelUpButton;
    public GameObject levelUpPanel;
    public TextMeshProUGUI levelUpTxt;

    [Header("Ingredient")]
    public TextMeshProUGUI fruitWorld;
    public TextMeshProUGUI rootsWorld;
    public TextMeshProUGUI boughWorld;

    public int fruitWorldCount = 0;
    public int rootsWorldCount = 0;
    public int boughWorldCount = 0;

    int ingredientCount;

    private void Awake()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
        inventoryManager = FindAnyObjectByType<InventoryManager>();

        levelUpPanel.SetActive(false);
        levelUpButton.GetComponent<Button>().enabled = false;
        levelPlayerTxt.color = Color.red;
        levelUpTxt.color = Color.red;

        ingredientCount = 1;
        levelUp = 10;

        LevelText();
        

    }

    public void LevelText()
    {
        

        levelPlayer = playerManager.levelPlayer;

        worldLevelTxt.text = worldLevel.ToString();

        levelPlayerTxt.text = "Level: " + levelPlayer + "/" + levelUp.ToString();

        if (levelPlayer >= levelUp && fruitWorldCount >= ingredientCount
            && rootsWorldCount >= ingredientCount && boughWorldCount >= ingredientCount)
        {
            levelUpPanel.SetActive(true);
            levelUpButton.GetComponent<Button>().enabled = true;


            levelPlayerTxt.color = Color.green;
            levelUpTxt.color = Color.green;

        }
    }

    public void LevelUp()
    {
        if(levelPlayer >= levelUp && fruitWorldCount >= ingredientCount
            && rootsWorldCount >= ingredientCount && boughWorldCount >= ingredientCount)
        {
            //AudioManager.instance.PlaySFX("Click");

            worldLevel += 1;
            levelUp += 10;

            LevelText();
            SetIngredient();

            if (levelPlayer < levelUp && fruitWorldCount >= ingredientCount
            || rootsWorldCount >= ingredientCount || boughWorldCount >= ingredientCount)
            {
                levelUpPanel.SetActive(false);
                levelUpButton.GetComponent<Button>().enabled = false;

                levelPlayerTxt.color = Color.red;
                levelUpTxt.color = Color.red;

            }
        }
    }

    public void Ingredient()
    {
        ingredientCount = worldLevel * 5;

        fruitWorld.text = 0 + "/" + ingredientCount.ToString();
        rootsWorld.text = 0 + "/" + ingredientCount.ToString();
        boughWorld.text = 0 + "/" + ingredientCount.ToString();

        fruitWorld.color = Color.red;
        rootsWorld.color = Color.red;
        boughWorld.color = Color.red;

        for (int i = 0; i < inventoryManager.inventoryItems.Count; i++)
        {
            var item = inventoryManager.inventoryItems[i];

            if ("FruitWorld" == item.itemName)
            {
                fruitWorldCount = item.quantity;
                fruitWorld.text = fruitWorldCount + "/" + ingredientCount.ToString();
                if (fruitWorldCount < ingredientCount)
                {
                    fruitWorld.color = Color.red;
                }
                else if (item.quantity >= ingredientCount)
                {
                    fruitWorld.color = Color.green;

                }
            }

            if ("RootsWorld" == item.itemName)
            {
                rootsWorldCount = item.quantity;
                rootsWorld.text = rootsWorldCount + "/" + ingredientCount.ToString();
                if (rootsWorldCount < ingredientCount)
                {
                    rootsWorld.color = Color.red;
                }
                else if (item.quantity >= ingredientCount)
                {
                    rootsWorld.color = Color.green;

                }
            }

            if ("BoughWorld" == item.itemName)
            {
                boughWorldCount = item.quantity;
                boughWorld.text = boughWorldCount + "/" + ingredientCount.ToString();
                if (boughWorldCount < ingredientCount)
                {
                    boughWorld.color = Color.red;
                }
                else if (item.quantity >= ingredientCount)
                {
                    boughWorld.color = Color.green;
                }
            }
        }
    }

    public void SetIngredient()
    {
        for(int i = 0;  i < inventoryManager.inventoryItems.Count; i++)
        {
            var item = inventoryManager.inventoryItems[i];

            if("FruitWorld" == item.itemName)
            {
                item.quantity -= ingredientCount;
                if(item.quantity <= 0)
                {
                    Destroy(item);
                }
            }

            if ("RootsWorld" == item.itemName)
            {
                item.quantity -= ingredientCount;
                if (item.quantity <= 0)
                {
                    Destroy(item);
                }
            }

            if ("BoughWorld" == item.itemName)
            {
                item.quantity -= ingredientCount;
                if (item.quantity <= 0)
                {
                    Destroy(item);
                }
            }
        }
    }
}
