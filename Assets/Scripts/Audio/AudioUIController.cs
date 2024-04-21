using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public TextMeshProUGUI musicText, sfxText;

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
        var music = musicSlider.value * 10;
        musicText.text = music.ToString("0");
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
        var sfx = sfxSlider.value * 10;
        sfxText.text = sfx.ToString("0");
    }
}
