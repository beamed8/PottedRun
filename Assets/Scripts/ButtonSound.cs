using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void PlaySingleSound(AudioClip clip)
    {
        SoundManager.instance.PlaySfx(clip);
    }

    public void PlayRandomClicks()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);
    }
}
