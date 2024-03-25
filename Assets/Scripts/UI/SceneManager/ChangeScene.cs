using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{
    public void ChangeScenes(string sceneName)
    {
        MapManager.Instance.Loader(sceneName);
    }
}
