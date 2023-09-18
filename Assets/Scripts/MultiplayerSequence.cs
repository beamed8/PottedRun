using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MultiplayerSequence : MonoBehaviour
{
    public static MultiplayerSequence instance;

    public List<CanvasGroup> screens;
    public int currentScreen = 0;
    public int previousScreen = 0;

    public TextMeshProUGUI connectingText;

    public Animator playerLoadingAnim;
    public Animator opponentLoadingAnim;

    public bool isPlayerReady = false;
    public bool isOpponentReady = false;

    private bool gameStarted = false;
    private bool gameEnded = false;

    public GameObject playerGo;
    public GameObject opponentGo;

    public GameObject multiplayerGo;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI endGameText;
    [Header("Connection UI")]
    public TextMeshProUGUI youText;
    public TextMeshProUGUI yourOpponentText;

    [Header("Player Ready UI")]
    public Image playerCharacter;
    public TextMeshProUGUI playerCharacterName;
    public TextMeshProUGUI playerReadyText;

    public GameObject selectCharacterButton;
    public GameObject readyButton;

    [Header("Opponent Ready UI")]
    public Image opponentCharacter;
    public TextMeshProUGUI opponentCharacterName;
    public TextMeshProUGUI opponentReadyText;

    [Header("Opponent Characters")]
    [Header("Bootoshi")]
    public Sprite bootoshiSprite;
    public string bootoshiName = "Bootoshi";
    public RuntimeAnimatorController bootoshiAnimator;
    [Header("Bootoshi")]
    public Sprite nekozumaSprite;
    public RuntimeAnimatorController nekozumaAnimator;
    public string nekozumaName = "Nekozuma";
    [Header("Bootoshi")]
    public Sprite thehiddenSprite;
    public RuntimeAnimatorController thehiddenAnimator;
    public string thehiddenName = "The Hidden";
    [Header("Bootoshi")]
    public Sprite deadkingSprite;
    public RuntimeAnimatorController deadkingAnimator;
    public string deadkingName = "Dead King";

    private bool isAnimating = false;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        StartCoroutine(ConnectingTextAnim());
        StartCoroutine(WholeRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     NextScreen();
        // }

        if (!gameStarted)
        {
            CheckForStart();
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < screens.Count; i++)
        {
            if (i == 0)
            {
                screens[i].alpha = 1;
            }
            else
            {
                screens[i].alpha = 0;
            }
        }
    }

    private void SetScreen(int index)
    {
        for (int i = 0; i < screens.Count; i++)
        {
            if (i == index)
            {
                // screens[i].alpha = 1;
                ChangeScreenAnim(screens[previousScreen], screens[currentScreen]);
            }
            // else
            // {
            //     screens[i].alpha = 0;
            // }
        }
    }

    public void NextScreen()
    {
        previousScreen = currentScreen;
        currentScreen++;
        SetScreen(currentScreen);
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);
    }

    private void ChangeScreenAnim(CanvasGroup from, CanvasGroup to)
    {
        StartCoroutine(ChangeScreenAnimSequence(from, to));
    }

    private IEnumerator ChangeScreenAnimSequence(CanvasGroup from, CanvasGroup to)
    {
        isAnimating = true;
        from.DOFade(0, 0.5f);
        from.interactable = false;
        from.blocksRaycasts = false;
        yield return new WaitForSeconds(0.5f);
        to.DOFade(1, 0.5f);
        to.interactable = true;
        to.blocksRaycasts = true;
        yield return new WaitForSeconds(0.5f);
        isAnimating = false;
    }

    public void SetPlayerCharacter(Sprite characterSprite, string characterName)
    {
        playerCharacter.sprite = characterSprite;
        playerCharacterName.text = characterName;
    }

    public void SetRandomOpponentCharacter()
    {
        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            opponentCharacter.sprite = bootoshiSprite;
            opponentCharacterName.text = bootoshiName;
            opponentGo.GetComponent<Animator>().runtimeAnimatorController = bootoshiAnimator;
        }
        else if (rand == 1)
        {
            opponentCharacter.sprite = nekozumaSprite;
            opponentCharacterName.text = nekozumaName;
            opponentGo.GetComponent<Animator>().runtimeAnimatorController = nekozumaAnimator;
        }
        else if (rand == 2)
        {
            opponentCharacter.sprite = thehiddenSprite;
            opponentCharacterName.text = thehiddenName;
            opponentGo.GetComponent<Animator>().runtimeAnimatorController = thehiddenAnimator;
        }
        else if (rand == 3)
        {
            opponentCharacter.sprite = deadkingSprite;
            opponentCharacterName.text = deadkingName;
            opponentGo.GetComponent<Animator>().runtimeAnimatorController = deadkingAnimator;
        }
    }

    public void SetOpponentReady()
    {
        isOpponentReady = true;
        opponentReadyText.text = "READY";
        opponentReadyText.color = Color.green;
    }

    public void PlayerReadyButton()
    {
        isPlayerReady = true;
        playerReadyText.text = "READY";
        playerReadyText.color = Color.green;
        selectCharacterButton.SetActive(false);
        readyButton.SetActive(false);

    }

    private void CheckForStart()
    {
        if (isPlayerReady && isOpponentReady)
        {
            gameStarted = true;
            StartCoroutine(StartGameRoutine());
        }
    }

    private IEnumerator StartGameRoutine()
    {
        playerGo.GetComponent<SpriteRenderer>().enabled = true;
        opponentGo.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(1f);
        NextScreen();
        yield return new WaitForSeconds(1f);
        countdownText.text = "READY?";
        countdownText.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        countdownText.text = "3..";
        countdownText.DOFade(1, 0f);
        countdownText.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        countdownText.text = "2..";
        countdownText.DOFade(1, 0f);
        countdownText.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        countdownText.text = "1..";
        countdownText.DOFade(1, 0f);
        countdownText.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        countdownText.text = "GO.";
        countdownText.DOFade(1, 0f);
        countdownText.DOFade(0, 0.25f);

        LevelManager.instance.StartGameButton();
        yield return new WaitForSeconds(0.25f);
        multiplayerGo.SetActive(false);
    }

    private IEnumerator ConnectingTextAnim()
    {
        connectingText.text = "Connecting";
        yield return new WaitForSeconds(0.5f);
        connectingText.text = "Connecting.";
        yield return new WaitForSeconds(0.5f);
        connectingText.text = "Connecting..";
        yield return new WaitForSeconds(0.5f);
        connectingText.text = "Connecting...";
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ConnectingTextAnim());
    }

    public IEnumerator SetPlayersReady()
    {
        yield return new WaitForSeconds(0.55f);
        playerLoadingAnim.SetTrigger("connected");
        youText.color = Color.green;
        yield return new WaitForSeconds(3f);
        opponentLoadingAnim.SetTrigger("connected");
        yourOpponentText.color = Color.green;
        yield return new WaitForSeconds(1.2f);
    }

    public IEnumerator WholeRoutine()
    {
        yield return new WaitForSeconds(2.5f);
        NextScreen();
        StartCoroutine(SetPlayersReady());
        yield return new WaitForSeconds(3.8f);
        NextScreen();
        yield return new WaitForSeconds(2.2f);
        SetRandomOpponentCharacter();
        yield return new WaitForSeconds(1f);
        SetRandomOpponentCharacter();
        yield return new WaitForSeconds(0.7f);
        SetRandomOpponentCharacter();
        yield return new WaitForSeconds(2f);
        SetRandomOpponentCharacter();
        yield return new WaitForSeconds(1f);
        SetOpponentReady();
    }

    public void PlayerWon()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            endGameText.text = "you won!";
            endGameText.color = Color.green;
        }
    }

    public void OpponentWon()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            endGameText.text = "you lost!";
            endGameText.color = Color.red;
        }
    }
}
