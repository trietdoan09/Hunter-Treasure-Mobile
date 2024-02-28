using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    [SerializeField] private GameObject[] spawnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        id = 7;
        //LoadData();
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadData()
    {
        PlayerData data = SaveSystem.LoadCharacterID();
        id = data.characterID;
    }
    private void SpawnPlayer()
    {
        var Player = Instantiate(spawnPlayer[id]);
        Player.transform.position = gameObject.transform.position;
    }
}
