using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Settings")]
    public bool isGameStarted = false;

    [Header("References")]
    public CanvasGroup inGameUI;
    public CanvasGroup clickToStart;
    public CanvasGroup gameOver;
    public TextMeshProUGUI lastScoreText;
    public CanvasGroup tryAgainButton;
    public CanvasGroup submitHighscoreButton;
    public CanvasGroup characterSelect;
    public CanvasGroup leaderboard;
    public CanvasGroup wallet;
    public TextMeshProUGUI walletText;
    public CanvasGroup walletCloseButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        SetupGame();
        tryAgainButton.interactable = false;
        submitHighscoreButton.interactable = false;
        leaderboard.interactable = false;
        // clickToStart.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

        SoundManager.instance.musicSource.volume = SoundManager.instance.defaultMusicVolume / 2;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(PlayerMovement.instance.primaryJumpKey) || Input.GetKeyDown(PlayerMovement.instance.alternativeJumpKey))
        // {
        //     if (!isGameStarted)
        //     {
        //         StartCoroutine(StartGame());
        //     }
        // }
    }

    public void StartGameButton()
    {
        if (!isGameStarted)
        {
            StartCoroutine(StartGame());
        }
    }

    public IEnumerator StartGame()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);
        SoundManager.instance.musicSource.volume = SoundManager.instance.defaultMusicVolume;
        if (!isGameStarted)
        {
            isGameStarted = true;
            clickToStart.interactable = false;
            clickToStart.blocksRaycasts = false;
            FadeCanvasGroup(clickToStart, 0, 0.5f);
            FadeCanvasGroup(inGameUI, 1, 1);

            AutoParallax[] bgs = GameObject.FindObjectsOfType<AutoParallax>();

            foreach (AutoParallax bg in bgs)
            {
                bg.StartMoving();
            }

            PlayerMovement.instance.canMove = true;
            yield return new WaitForSeconds(0.1f);
            PlayerMovement.instance.canJump = true;
        }
    }

    private void SetupGame()
    {
        isGameStarted = false;

        AutoParallax[] bgs = GameObject.FindObjectsOfType<AutoParallax>();

        foreach (AutoParallax bg in bgs)
        {
            bg.StopMoving();
        }

        PlayerMovement.instance.canJump = false;
        PlayerMovement.instance.canMove = false;
    }

    private void FadeCanvasGroup(CanvasGroup target, float fadeTo, float duration)
    {
        target.DOFade(fadeTo, duration);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    private IEnumerator GameOverRoutine()
    {
        if (!gameOver.gameObject.activeInHierarchy)
        {
            gameOver.gameObject.SetActive(true);
        }
        lastScoreText.text = "your score: <color=yellow>" + PlayerScore.instance.score.ToString() + "</color>";

        FadeCanvasGroup(inGameUI, 0, 1);

        tryAgainButton.interactable = false;
        yield return new WaitForSeconds(1.5f);
        FadeCanvasGroup(gameOver, 1, 1.5f);
        yield return new WaitForSeconds(1.8f);
        FadeCanvasGroup(tryAgainButton, 1, 0.5f);
        FadeCanvasGroup(submitHighscoreButton, 1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        tryAgainButton.interactable = true;
        submitHighscoreButton.interactable = true;
    }

    public void CharacterScreen()
    {
        StartCoroutine(CharacterScreenRoutine());
    }

    private IEnumerator CharacterScreenRoutine()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);

        clickToStart.interactable = false;
        clickToStart.blocksRaycasts = false;
        FadeCanvasGroup(clickToStart, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        FadeCanvasGroup(characterSelect, 1, 0.2f);
        yield return new WaitForSeconds(0.2f);
        characterSelect.interactable = true;
        characterSelect.blocksRaycasts = true;
    }

    public void SelectCharacter()
    {
        StartCoroutine(SelectCharacterRoutine());
    }

    private IEnumerator SelectCharacterRoutine()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);

        characterSelect.interactable = false;
        characterSelect.blocksRaycasts = false;
        FadeCanvasGroup(characterSelect, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        FadeCanvasGroup(clickToStart, 1, 0.2f);
        yield return new WaitForSeconds(0.2f);
        clickToStart.interactable = true;
        clickToStart.blocksRaycasts = true;
    }

    public void ShowLeaderboard()
    {
        StartCoroutine(ShowLeaderboardRoutine());
    }

    private IEnumerator ShowLeaderboardRoutine()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);

        gameOver.interactable = false;
        gameOver.blocksRaycasts = false;
        FadeCanvasGroup(gameOver, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        FadeCanvasGroup(leaderboard, 1, 0.2f);
        yield return new WaitForSeconds(0.2f);
        leaderboard.interactable = true;
        leaderboard.blocksRaycasts = true;
    }

    public void EnableWallet()
    {
        StartCoroutine(EnableWalletRoutine());
    }

    private IEnumerator EnableWalletRoutine()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);

        clickToStart.interactable = false;
        clickToStart.blocksRaycasts = false;
        FadeCanvasGroup(clickToStart, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        FadeCanvasGroup(wallet, 1, 0.2f);
        yield return new WaitForSeconds(0.2f);
        wallet.interactable = true;
        wallet.blocksRaycasts = true;
    }

    public void EnableCloseWalletButton()
    {
        walletCloseButton.alpha = 1;
        walletCloseButton.interactable = true;
        walletCloseButton.blocksRaycasts = true;
        // StartCoroutine(EnableCloseWalletButtonRoutine());
    }

    private IEnumerator EnableCloseWalletButtonRoutine()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.dropSounds);

        FadeCanvasGroup(walletCloseButton, 1, 0.2f);
        yield return new WaitForSeconds(0.2f);
        walletCloseButton.interactable = true;
        walletCloseButton.blocksRaycasts = true;
    }

    public void CloseWallet()
    {
        StartCoroutine(CloseWalletRoutine());
    }

    private IEnumerator CloseWalletRoutine()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);

        wallet.interactable = false;
        wallet.blocksRaycasts = false;
        FadeCanvasGroup(wallet, 0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        FadeCanvasGroup(clickToStart, 1, 0.2f);
        yield return new WaitForSeconds(0.2f);
        clickToStart.interactable = true;
        clickToStart.blocksRaycasts = true;
    }

    public void SetWalletText(string text)
    {
        walletText.text = text;
    }

}