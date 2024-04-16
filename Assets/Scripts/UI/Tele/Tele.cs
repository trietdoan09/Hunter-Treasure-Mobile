using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tele : MonoBehaviour
{
    public GameObject teleName;
    public GameObject telePort;

    public Button jungleButton, desertButton, dungeonButton;
    public string jungleExit, desertExit, dungeonExit;
    public string jungleName, desertName, dungeonName;

    void Start()
    {
        teleName.SetActive(false);
        telePort.SetActive(false);

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            teleName.SetActive(true);
        }
    }


    public void LoadScene(string exitName, string sceneToLoad)
    {
        PlayerPrefs.SetString("LastExitName", exitName);

        MapManager.Instance.Loader(sceneToLoad);
    }
}
