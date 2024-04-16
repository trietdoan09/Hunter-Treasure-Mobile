using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldLevel : MonoBehaviour
{
    public int worldLevel;
    public TextMeshProUGUI worldLevelTxt;


    private void Awake()
    {
        worldLevelTxt.text = worldLevel.ToString();
    }


    public void LevelUp()
    {
        worldLevel += 1;
        worldLevelTxt.text = worldLevel.ToString();

    }
}
