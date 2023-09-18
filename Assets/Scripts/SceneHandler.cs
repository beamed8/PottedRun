using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance;

    private Animator fade;

    private bool firstLoad = true;

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
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.K))
        // {
        //     ChangeScene("wallet_scene");
        // }
    }

    public void ChangeScene(string scene)
    {
        StartCoroutine(ChangeSceneRoutine(scene));
    }

    private IEnumerator ChangeSceneRoutine(string sceneName)
    {
        fade.SetTrigger("FadeIn");
        // SoundManager.instance.FadeMusicOut(0.75f);
        yield return new WaitForSeconds(.9f);
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(.1f);
        fade.SetTrigger("FadeOut");
        SetMusic();
        // SoundManager.instance.FadeMusicIn(0.5f);
    }

    public void RestartScene()
    {
        StartCoroutine(ChangeSceneRoutine(SceneManager.GetActiveScene().name));
    }

    private void SetMusic()
    {
        // if (SceneManager.GetActiveScene().name == "Menu")
        // {
        //     SoundManager.instance.ChangeMusic(SoundManager.instance.menuMusic);
        // }

        // if (SceneManager.GetActiveScene().name == "Forest")
        // {
        //     SoundManager.instance.ChangeMusic(SoundManager.instance.forestMusic);
        //     // StartCoroutine(CreateDelay(1.5f));
        // }

        // if (SceneManager.GetActiveScene().name == "Castle")
        // {
        //     SoundManager.instance.ChangeMusic(SoundManager.instance.castleMusic);
        // }
    }

    private IEnumerator CreateDelay(float delay)
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1;
    }
}
