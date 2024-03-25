using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenManager : MonoBehaviour
{
    public GameObject notificationLoadscene;
    public string sceneToLoad;
    public string exitName;

    private void Start()
    {
        notificationLoadscene.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        notificationLoadscene.SetActive(true);
    }

    public void LoadScene()
    {
        PlayerPrefs.SetString("LastExitName", exitName);

        MapManager.Instance.Loader(sceneToLoad);
        //SceneManager.LoadScene(sceneToLoad);
    }
}
