using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldLevel : MonoBehaviour
{
    PlayerManager playerManager;


    public int worldLevel = 1;
    public TextMeshProUGUI worldLevelTxt;

     int levelPlayer;
     int levelUp;
    public TextMeshProUGUI levelPlayerTxt;

    public GameObject levelUpButton;
    public GameObject levelUpPanel;
    public TextMeshProUGUI levelUpTxt;
   

    private void Awake()
    {
        playerManager = FindAnyObjectByType<PlayerManager>();
        levelUpPanel.SetActive(false);
        levelUpButton.GetComponent<Button>().enabled = false;
        levelPlayerTxt.color = Color.red;
        levelUpTxt.color = Color.red;

        levelUp = 10;

        LevelText();

    }

    public void LevelText()
    {
        

        levelPlayer = playerManager.levelPlayer;

        worldLevelTxt.text = worldLevel.ToString();

        levelPlayerTxt.text = "Level: " + levelPlayer + "/" + levelUp.ToString();

        if (levelPlayer >= levelUp)
        {
            levelUpPanel.SetActive(true);
            levelUpButton.GetComponent<Button>().enabled = true;


            levelPlayerTxt.color = Color.green;
            levelUpTxt.color = Color.green;

        }
    }

    public void LevelUp()
    {
        if(levelPlayer >= levelUp)
        {
            worldLevel += 1;
            levelUp += 10;

            LevelText();

            if(levelPlayer < levelUp)
            {
                levelUpPanel.SetActive(false);
                levelUpButton.GetComponent<Button>().enabled = false;

                levelPlayerTxt.color = Color.red;
                levelUpTxt.color = Color.red;

            }
        }
    }
}
