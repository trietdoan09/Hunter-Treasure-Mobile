using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClick : MonoBehaviour
{
   public void SoundsClick()
    {
        AudioManager.instance.PlaySFX("Click");
    }
    public void SoundClose()
    {
        AudioManager.instance.PlaySFX("Close");

    }
}
