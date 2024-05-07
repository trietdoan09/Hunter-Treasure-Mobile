using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSound, sfxSound;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {

        Sound sound = Array.Find(musicSound, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("not sound");
        }

        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {

        Sound sound = Array.Find(sfxSound, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("not sound");
        }

        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
