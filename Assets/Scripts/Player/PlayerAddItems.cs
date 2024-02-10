using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerAddItems : MonoBehaviour
{
    public static PlayerAddItems Instance;

    public int HP;
    public int MP;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI MPText;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseHP(int value)
    {
        HP += value;
        HPText.text = HP.ToString();
    }
    public void IncreaseMP(int value)
    {
        MP += value;
        MPText.text = MP.ToString();
    }
}
