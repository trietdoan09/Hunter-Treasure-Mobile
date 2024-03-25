using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenManager : MonoBehaviour
{
    public string sceneToLoad;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
