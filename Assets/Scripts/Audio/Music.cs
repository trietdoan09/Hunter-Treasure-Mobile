using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioManager manager;

    public string music;
    void Start()
    {
        manager = FindAnyObjectByType<AudioManager>();

        manager.PlayMusic(music);
    }
}
