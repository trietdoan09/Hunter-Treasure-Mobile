using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public string lastExitName;

    private void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitName )
        {

            PlayerScript.instance.transform.position = transform.position;
            PlayerScript.instance.transform.eulerAngles = transform.eulerAngles;

        }
    }
}
