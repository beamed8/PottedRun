using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Image musicMuteButton;
    public Sprite mutedSprite;
    public Sprite unmutedSprite;
    // Start is called before the first frame update
    void Start()
    {
        SetStatus();
    }

    public void ToggleMusic()
    {
        int currentMusicMute = PlayerPrefs.GetInt("musicmute");

        if (currentMusicMute == 0)
        {
            // MUTE BUTTON
            SoundManager.instance.musicSource.mute = true;
            musicMuteButton.sprite = mutedSprite;
            PlayerPrefs.SetInt("musicmute", 1);
        }
        else if (currentMusicMute == 1)
        {
            // UNMUTE BUTTON
            SoundManager.instance.musicSource.mute = false;
            musicMuteButton.sprite = unmutedSprite;
            PlayerPrefs.SetInt("musicmute", 0);
        }
    }

    public void SetStatus()
    {
        int currentMusicMute = PlayerPrefs.GetInt("musicmute");

        if (currentMusicMute == 0)
        {
            // IS UNMUTED
            SoundManager.instance.musicSource.mute = false;
            musicMuteButton.sprite = unmutedSprite;
        }
        else if (currentMusicMute == 1)
        {
            // MUTED
            SoundManager.instance.musicSource.mute = true;
            musicMuteButton.sprite = mutedSprite;
        }
    }
}
