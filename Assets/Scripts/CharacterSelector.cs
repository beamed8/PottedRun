using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;

    [Header("Settings")]
    public Character currentCharacter;

    [Header("Characters")]
    [Header("Famous Fox Federation")]
    public RuntimeAnimatorController fffAnimator;
    public bool isFFFGhosting = false;
    public bool isFFFSpecialBackground = false;
    public Sprite fffAvatar;
    public string fffCharacterName = "Famous Fox Federation";

    [Header("Potted P")]
    public RuntimeAnimatorController potAnimator;
    public bool isPotGhosting = false;
    public bool isPotSpecialBackground = false;
    public Sprite potAvatar;
    public string potCharacterName = "Potted P";

    [Header("The Hidden")]
    public RuntimeAnimatorController hiddenAnimator;
    public bool isHiddenGhosting = true;
    public bool isHiddenSpecialBackground = false;
    public Sprite hiddenAvatar;
    public string hiddenCharacterName = "The Hidden";

    [Header("Alpha Pharaoh")]
    public RuntimeAnimatorController pharaohAnimator;
    public bool isPharaohGhosting = true;
    public bool isPharaohSpecialBackground = false;
    public Sprite pharaohAvatar;
    public string pharaohCharacterName = "The Hidden";

    [Header("BVDCAT")]
    public RuntimeAnimatorController bvdcatAnimator;
    public bool isBvdcatGhosting = true;
    public bool isBvdcatSpecialBackground = false;
    public Sprite bvdcatAvatar;
    public string bvdcatCharacterName = "The Hidden";

    [Header("Ghost Kid")]
    public RuntimeAnimatorController ghostkidAnimator;
    public bool isGhostkidGhosting = true;
    public bool isGhostkidSpecialBackground = false;
    public Sprite ghostkidAvatar;
    public string ghostkidCharacterName = "The Hidden";

    [Header("The Immortal")]
    public RuntimeAnimatorController immortalAnimator;
    public bool isImmortalGhosting = true;
    public bool isImmortalSpecialBackground = false;
    public Sprite immortalAvatar;
    public string immortalCharacterName = "The Hidden";

    [Header("Nekozuma")]
    public RuntimeAnimatorController nekozumaAnimator;
    public bool isNekozumaGhosting = true;
    public bool isNekozumaSpecialBackground = false;
    public Sprite nekozumaAvatar;
    public string nekozumaCharacterName = "The Hidden";

    [Header("The Pixel Dude")]
    public RuntimeAnimatorController pixeldudeAnimator;
    public bool isPixeldudeGhosting = true;
    public bool isPixeldudeSpecialBackground = false;
    public Sprite pixeldudeAvatar;
    public string pixeldudeCharacterName = "The Hidden";

    [Header("BTC Machine")]
    public RuntimeAnimatorController btcmachineAnimator;
    public bool isBtcmachineGhosting = true;
    public bool isBtcmachineSpecialBackground = false;
    public Sprite btcmachineAvatar;
    public string btcmachineCharacterName = "BTC Machine";

    [Header("Ordinal Rabbit")]
    public RuntimeAnimatorController ordinalrabbitAnimator;
    public bool isOrdinalrabbitGhosting = true;
    public bool isOrdinalrabbitSpecialBackground = false;
    public Sprite ordinalrabbitAvatar;
    public string ordinalrabbitCharacterName = "Ordinal Rabbit";

    [Header("Satoshi Shellz")]
    public RuntimeAnimatorController satoshishellzAnimator;
    public bool isSatoshishellzGhosting = true;
    public bool isSatoshishellzSpecialBackground = false;
    public Sprite satoshishellzAvatar;
    public string satoshishellzCharacterName = "Satoshi Shellz";

    [Header("Doge Capital")]
    public RuntimeAnimatorController dogecapitalAnimator;
    public bool isDogecapitalGhosting = true;
    public bool isDogecapitalSpecialBackground = false;
    public Sprite dogecapitalzAvatar;
    public string dogecapitalCharacterName = "Doge Capital";

    [Header("Dead King Society")]
    public RuntimeAnimatorController deadkingAnimator;
    public bool isDeadkingGhosting = true;
    public bool isDeadkingSpecialBackground = false;
    public Sprite deadkingAvatar;
    public string deadkingCharacterName = "Dead Kings";

    [Header("Bootoshi")]
    public RuntimeAnimatorController bootoshiAnimator;
    public bool isBootoshiGhosting = false;
    public bool isBootoshiSpecialBackground = false;
    public Sprite bootoshiAvatar;
    public string bootoshiCharacterName = "Bootoshi";

    [Header("References")]
    public Ghost playerGhost;
    public Animator playerAnimator;
    public Image playerAvatar;
    public TextMeshProUGUI characterNameSelectScreen;
    public TextMeshProUGUI characterNameGameScreen;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // SelectBootoshi();
        SetCharacter();
    }

    public void SelectFFF()
    {
        currentCharacter = Character.FFF;
        playerGhost.createGhost = isFFFGhosting;
        playerAnimator.runtimeAnimatorController = fffAnimator;

        playerAvatar.sprite = fffAvatar;
        characterNameSelectScreen.text = fffCharacterName;
        characterNameGameScreen.text = fffCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(fffAvatar, fffCharacterName);
        //MULTIPLAYER END

        if (isFFFSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "fff");
    }

    public void SelectHidden()
    {
        currentCharacter = Character.Hidden;
        playerGhost.createGhost = isHiddenGhosting;
        playerAnimator.runtimeAnimatorController = hiddenAnimator;

        playerAvatar.sprite = hiddenAvatar;
        characterNameSelectScreen.text = hiddenCharacterName;
        characterNameGameScreen.text = hiddenCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(hiddenAvatar, hiddenCharacterName);
        //MULTIPLAYER END

        if (isHiddenSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "thehidden");
    }

    public void SelectPottedP()
    {
        currentCharacter = Character.PottedP;
        playerGhost.createGhost = isPotGhosting;
        playerAnimator.runtimeAnimatorController = potAnimator;

        playerAvatar.sprite = potAvatar;
        characterNameSelectScreen.text = potCharacterName;
        characterNameGameScreen.text = potCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(potAvatar, potCharacterName);
        //MULTIPLAYER END

        if (isPotSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "pottedp");
    }

    public void SelectPharaoh()
    {
        currentCharacter = Character.Pharaoh;
        playerGhost.createGhost = isPharaohGhosting;
        playerAnimator.runtimeAnimatorController = pharaohAnimator;

        playerAvatar.sprite = pharaohAvatar;
        characterNameSelectScreen.text = pharaohCharacterName;
        characterNameGameScreen.text = pharaohCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(pharaohAvatar, pharaohCharacterName);
        //MULTIPLAYER END

        if (isHiddenSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "alphapharaoh");
    }

    public void SelectBVDCAT()
    {
        currentCharacter = Character.BVDCAT;
        playerGhost.createGhost = isBvdcatGhosting;
        playerAnimator.runtimeAnimatorController = bvdcatAnimator;

        playerAvatar.sprite = bvdcatAvatar;
        characterNameSelectScreen.text = bvdcatCharacterName;
        characterNameGameScreen.text = bvdcatCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(bvdcatAvatar, bvdcatCharacterName);
        //MULTIPLAYER END

        if (isBvdcatSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "bvdcat");
    }

    public void SelectGhostkid()
    {
        currentCharacter = Character.GhostKid;
        playerGhost.createGhost = isGhostkidGhosting;
        playerAnimator.runtimeAnimatorController = ghostkidAnimator;

        playerAvatar.sprite = ghostkidAvatar;
        characterNameSelectScreen.text = ghostkidCharacterName;
        characterNameGameScreen.text = ghostkidCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(ghostkidAvatar, ghostkidCharacterName);
        //MULTIPLAYER END

        if (isGhostkidSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "ghostkid");
    }

    public void SelectImmortal()
    {
        currentCharacter = Character.Immortal;
        playerGhost.createGhost = isImmortalGhosting;
        playerAnimator.runtimeAnimatorController = immortalAnimator;

        playerAvatar.sprite = immortalAvatar;
        characterNameSelectScreen.text = immortalCharacterName;
        characterNameGameScreen.text = immortalCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(immortalAvatar, immortalCharacterName);
        //MULTIPLAYER END

        if (isImmortalSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "theimmortal");
    }

    public void SelectNekozuma()
    {
        currentCharacter = Character.Nekozuma;
        playerGhost.createGhost = isNekozumaGhosting;
        playerAnimator.runtimeAnimatorController = nekozumaAnimator;

        playerAvatar.sprite = nekozumaAvatar;
        characterNameSelectScreen.text = nekozumaCharacterName;
        characterNameGameScreen.text = nekozumaCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(nekozumaAvatar, nekozumaCharacterName);
        //MULTIPLAYER END

        if (isNekozumaSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "nekozuma");
    }

    public void SelectPixelDude()
    {
        currentCharacter = Character.PixelDude;
        playerGhost.createGhost = isPixeldudeGhosting;
        playerAnimator.runtimeAnimatorController = pixeldudeAnimator;

        playerAvatar.sprite = pixeldudeAvatar;
        characterNameSelectScreen.text = pixeldudeCharacterName;
        characterNameGameScreen.text = pixeldudeCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(pixeldudeAvatar, pixeldudeCharacterName);
        //MULTIPLAYER END

        if (isPixeldudeSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "pixeldude");
    }

    public void SelectBTCMachine()
    {
        currentCharacter = Character.BTCMachine;
        playerGhost.createGhost = isBtcmachineGhosting;
        playerAnimator.runtimeAnimatorController = btcmachineAnimator;

        playerAvatar.sprite = btcmachineAvatar;
        characterNameSelectScreen.text = btcmachineCharacterName;
        characterNameGameScreen.text = btcmachineCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(btcmachineAvatar, btcmachineCharacterName);
        //MULTIPLAYER END

        if (isBtcmachineSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "btcmachine");
    }

    public void SelectOrdinalRabbit()
    {
        currentCharacter = Character.OrdinalRabbit;
        playerGhost.createGhost = isOrdinalrabbitGhosting;
        playerAnimator.runtimeAnimatorController = ordinalrabbitAnimator;

        playerAvatar.sprite = ordinalrabbitAvatar;
        characterNameSelectScreen.text = ordinalrabbitCharacterName;
        characterNameGameScreen.text = ordinalrabbitCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(ordinalrabbitAvatar, ordinalrabbitCharacterName);
        //MULTIPLAYER END

        if (isOrdinalrabbitSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "ordinalrabbit");
    }

    public void SelectSatoshiShellz()
    {
        currentCharacter = Character.SatoshiShellz;
        playerGhost.createGhost = isSatoshishellzGhosting;
        playerAnimator.runtimeAnimatorController = satoshishellzAnimator;

        playerAvatar.sprite = satoshishellzAvatar;
        characterNameSelectScreen.text = satoshishellzCharacterName;
        characterNameGameScreen.text = satoshishellzCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(satoshishellzAvatar, satoshishellzCharacterName);
        //MULTIPLAYER END

        if (isSatoshishellzSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "satoshishellz");
    }

    public void SelectDogeCapital()
    {
        currentCharacter = Character.DogeCapital;
        playerGhost.createGhost = isDogecapitalGhosting;
        playerAnimator.runtimeAnimatorController = dogecapitalAnimator;

        playerAvatar.sprite = dogecapitalzAvatar;
        characterNameSelectScreen.text = dogecapitalCharacterName;
        characterNameGameScreen.text = dogecapitalCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(dogecapitalzAvatar, dogecapitalCharacterName);
        //MULTIPLAYER END

        if (isDogecapitalSpecialBackground)
        {
            // BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "dogecapital");
    }

    public void SelectDeadKing()
    {
        currentCharacter = Character.DeadKing;
        playerGhost.createGhost = isDeadkingGhosting;
        playerAnimator.runtimeAnimatorController = deadkingAnimator;

        playerAvatar.sprite = deadkingAvatar;
        characterNameSelectScreen.text = deadkingCharacterName;
        characterNameGameScreen.text = deadkingCharacterName;

        //MULTIPLAYER START
        MultiplayerSequence.instance.SetPlayerCharacter(deadkingAvatar, deadkingCharacterName);
        //MULTIPLAYER END

        if (isDeadkingSpecialBackground)
        {
            BackgroundChanger.instance.DeadKingSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "deadking");
    }

    public void SelectBootoshi()
    {
        currentCharacter = Character.Bootoshi;
        playerGhost.createGhost = isBootoshiGhosting;
        playerAnimator.runtimeAnimatorController = bootoshiAnimator;

        playerAvatar.sprite = bootoshiAvatar;
        characterNameSelectScreen.text = bootoshiCharacterName;
        characterNameGameScreen.text = bootoshiCharacterName;

        //MULTIPLAYER START
        // MultiplayerSequence.instance.SetPlayerCharacter(bootoshiAvatar, bootoshiCharacterName);
        //MULTIPLAYER END

        if (isBootoshiSpecialBackground)
        {
            BackgroundChanger.instance.BootoshiSetting();
        }
        else
        {
            BackgroundChanger.instance.isForcedBackground = false;
            BackgroundChanger.instance.SetBackground();
        }

        PlayerPrefs.SetString("character", "bootoshi");
    }


    public string GetCurrentCharacterName()
    {
        return characterNameGameScreen.text;
    }

    private void SetCharacter()
    {
        string selectedCharacter = PlayerPrefs.GetString("character");
        if (selectedCharacter == "pottedp")
        {
            SelectPottedP();
        }
        else if (selectedCharacter == "thehidden")
        {
            SelectHidden();
        }
        else if (selectedCharacter == "fff")
        {
            SelectFFF();
        }
        else if (selectedCharacter == "alphapharaoh")
        {
            SelectPharaoh();
        }
        else if (selectedCharacter == "bvdcat")
        {
            SelectBVDCAT();
        }
        else if (selectedCharacter == "ghostkid")
        {
            SelectGhostkid();
        }
        else if (selectedCharacter == "theimmortal")
        {
            SelectImmortal();
        }
        else if (selectedCharacter == "nekozuma")
        {
            SelectNekozuma();
        }
        else if (selectedCharacter == "pixeldude")
        {
            SelectPixelDude();
        }
        else if (selectedCharacter == "btcmachine")
        {
            SelectBTCMachine();
        }
        else if (selectedCharacter == "ordinalrabbit")
        {
            SelectOrdinalRabbit();
        }
        else if (selectedCharacter == "satoshishellz")
        {
            SelectSatoshiShellz();
        }
        else if (selectedCharacter == "dogecapital")
        {
            SelectDogeCapital();
        }
        else if (selectedCharacter == "deadking")
        {
            SelectDeadKing();
        }
        else if (selectedCharacter == "bootoshi")
        {
            SelectBootoshi();
        }
        else
        {
            SelectPottedP();
        }
    }

    public void CheckCharacterUnlocked()
    {
        if (currentCharacter == Character.FFF && CharacterUnlockBools.instance.isFamousFoxFedUnlocked == false)
        {
            Debug.Log("FFF not unlocked anymore.");
            SelectPottedP();
        }
    }
}

public enum Character
{
    PottedP,
    FFF,
    Hidden,
    Pharaoh,
    BVDCAT,
    GhostKid,
    Immortal,
    Nekozuma,
    PixelDude,
    BTCMachine,
    OrdinalRabbit,
    SatoshiShellz,
    DogeCapital,
    DeadKing,
    Bootoshi
}
