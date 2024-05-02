using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tele : MonoBehaviour
{
    public GameObject teleName;
    public GameObject telePort;

    public Button jungleButton, desertButton, dungeonButton;
    public Button jungleBoss, desertBoss, dungeonBoss;

    public string jungleExit, desertExit, dungeonExit;
    public string jungleName, desertName, dungeonName;

    public string bossJungleExit, bossDesertExit, bossDungeonExit;
    public string bossJungleName, bossDesertName, bossDungeonName;

    void Start()
    {
        teleName.SetActive(false);
        telePort.SetActive(false);

        //Map
        jungleButton.onClick.AddListener(() =>
        {
            LoadScene(jungleExit, jungleName);
        });

        desertButton.onClick.AddListener(() =>
        {
            LoadScene(desertExit, desertName);
        });

        dungeonButton.onClick.AddListener(() =>
        {
            LoadScene(dungeonExit, dungeonName);
        });

        //Boss
        jungleBoss.onClick.AddListener(() =>
        {
            LoadScene(bossJungleExit, bossJungleName);
        });

        desertBoss.onClick.AddListener(() =>
        {
            LoadScene(bossDesertExit, bossDesertName);
        });

        dungeonBoss.onClick.AddListener(() =>
        {
            LoadScene(bossDungeonExit, bossDungeonName);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        teleName.SetActive(true);

    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        teleName.SetActive(false);

        telePort.SetActive(false);
    }

    public void LoadScene(string exitName, string sceneToLoad)
    {
        telePort.SetActive(false);

        PlayerPrefs.SetString("LastExitName", exitName);

        MapManager.Instance.Loader(sceneToLoad);
    }
}
