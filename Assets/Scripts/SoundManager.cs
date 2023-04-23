using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Settings")]
    public float defaultMusicVolume;
    public float defaultSfxVolume;
    public bool isMusicMuted;
    public bool isSfxMuted;

    [Header("Sounds")]
    // public AudioClip dropCollect;
    public AudioClip superDropCollect;
    // public AudioClip gameOver;
    public AudioClip tryAgain;
    public AudioClip clickToStart;
    public AudioClip playerHit;

    [Header("Music")]
    public AudioClip springMusic;
    public AudioClip summerMusic;
    public AudioClip autumnMusic;
    public AudioClip winterMusic;
    public AudioClip deadkingMusic;
    public AudioClip bootoshiMusic;

    [Header("Sound Lists")]
    public AudioClip[] jumpingSounds;
    public AudioClip[] clickSounds;
    public AudioClip[] dropSounds;

    [Header("References")]
    public Image musicMute;
    public Sprite musicMutedSprite;
    public Sprite musicUnmutedSprite;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        sfxSource.volume = defaultSfxVolume;
        musicSource.volume = defaultMusicVolume;
        SetMuteStatus();
        // musicMute = GameObject.Find("MuteMusicButton").GetComponent<Image>();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }

    public void PlayRandomFromList(AudioClip[] list)
    {
        if (list.Length > 0)
        {
            int rand = Random.Range(0, list.Length);
            PlaySfx(list[rand]);
        }
    }

    public void ChangeMusic(AudioClip clip)
    {
        if (musicSource.isPlaying)
        {
            if (musicSource.clip == clip) return;
            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.Play();
        }
        else
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void FadeMusicOut(float time)
    {
        if (!DOTween.IsTweening(musicSource))
        {
            musicSource.DOFade(0, time);
        }
        else
        {
            musicSource.DOComplete();
        }
    }

    public void FadeMusicIn(float time)
    {
        if (!DOTween.IsTweening(musicSource))
        {
            musicSource.DOFade(defaultMusicVolume, time);
        }
        else
        {
            musicSource.DOComplete();
        }
    }

    public void ToggleMusic()
    {
        int currentMusicMute = PlayerPrefs.GetInt("musicmute");

        if (currentMusicMute == 0)
        {
            // MUTE BUTTON
            musicSource.mute = true;
            // musicMute.sprite = musicMutedSprite;
            PlayerPrefs.SetInt("musicmute", 1);
        }
        else if (currentMusicMute == 1)
        {
            // UNMUTE BUTTON
            musicSource.mute = false;
            // musicMute.sprite = musicUnmutedSprite;
            PlayerPrefs.SetInt("musicmute", 0);
        }
    }

    private void SetMuteStatus()
    {
        int currentMusicMute = PlayerPrefs.GetInt("musicmute");

        if (currentMusicMute == 0)
        {
            // IS NOT MUTED
            musicSource.mute = false;
            musicMute.sprite = musicUnmutedSprite;
        }
        else if (currentMusicMute == 1)
        {
            // IS MUTED
            musicSource.mute = true;
            musicMute.sprite = musicMutedSprite;
        }
    }

}
