using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
       
    }
    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadCharacterID();
        id = data.characterID;
    }
}
