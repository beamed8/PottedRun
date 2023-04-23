using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUnlocker : MonoBehaviour
{
    public static CharacterUnlocker instance;

    private CharacterUnlockBools cub;

    [Header("Character Buttons")]
    public Button PottedPButton;
    public Button FamousFoxFedButton;
    public Button TheHiddenButton;
    public Button AlphaPharaohButton;
    public Button BVDCATButton;
    public Button GhostKidButton;
    public Button TheImmortalButton;
    public Button NekozumaButton;
    public Button ThePixelDudeButton;
    public Button BTCMachineButton;
    public Button OrdinalRabbitButton;
    public Button SatoshiShellzButton;
    public Button DogeCapitalButton;
    public Button DeadKingButton;
    public Button BootoshiButton;

    [Header("Character Avatars")]
    public Image PottedPAvatar;
    public Image FamousFoxFedAvatar;
    public Image TheHiddenAvatar;
    public Image AlphaPharaohAvatar;
    public Image BVDCATAvatar;
    public Image GhostKidAvatar;
    public Image TheImmortalAvatar;
    public Image NekozumaAvatar;
    public Image ThePixelDudeAvatar;
    public Image BTCMachineAvatar;
    public Image OrdinalRabbitAvatar;
    public Image SatoshiShellzAvatar;
    public Image DogeCapitalAvatar;
    public Image DeadKingAvatar;
    public Image BootoshiAvatar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        cub = CharacterUnlockBools.instance;
    }

    void Start()
    {
        // int pw = PlayerPrefs.GetInt("phantomwallet");
        // if (pw == 0)
        // {
        DisableAllCharacters();
        // }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.H))
        // {
        //     EnableCharacter(TheHiddenButton, TheHiddenAvatar, cub.isTheHiddenUnlocked);
        // }
    }

    public void UnlockCharacter(string charName)
    {
        if (charName == "pottedp")
        {
            EnableCharacter(PottedPButton, PottedPAvatar, cub.isPottedPUnlocked);
            CharacterUnlockBools.instance.isPottedPUnlocked = true;
        }

        if (charName == "fff")
        {
            EnableCharacter(FamousFoxFedButton, FamousFoxFedAvatar, cub.isFamousFoxFedUnlocked);
            CharacterUnlockBools.instance.isFamousFoxFedUnlocked = true;
        }

        if (charName == "thehidden")
        {
            EnableCharacter(TheHiddenButton, TheHiddenAvatar, cub.isTheHiddenUnlocked);
            CharacterUnlockBools.instance.isTheHiddenUnlocked = true;
        }

        if (charName == "alphapharaoh")
        {
            EnableCharacter(AlphaPharaohButton, AlphaPharaohAvatar, cub.isAlphaPharaohUnlocked);
            CharacterUnlockBools.instance.isAlphaPharaohUnlocked = true;
        }

        if (charName == "bvdcat")
        {
            EnableCharacter(BVDCATButton, BVDCATAvatar, cub.isBVDCATUnlocked);
            CharacterUnlockBools.instance.isBVDCATUnlocked = true;
        }

        if (charName == "ghostkid")
        {
            EnableCharacter(GhostKidButton, GhostKidAvatar, cub.isGhostKidUnlocked);
            CharacterUnlockBools.instance.isGhostKidUnlocked = true;
        }

        if (charName == "nekozuma")
        {
            EnableCharacter(NekozumaButton, NekozumaAvatar, cub.isNekozumaUnlocked);
            CharacterUnlockBools.instance.isNekozumaUnlocked = true;
        }

        if (charName == "thepixeldude")
        {
            EnableCharacter(ThePixelDudeButton, ThePixelDudeAvatar, cub.isThePixelDudeUnlocked);
            CharacterUnlockBools.instance.isThePixelDudeUnlocked = true;
        }

        if (charName == "dogecapital")
        {
            EnableCharacter(DogeCapitalButton, DogeCapitalAvatar, cub.isDogeCapitalUnlocked);
            CharacterUnlockBools.instance.isDogeCapitalUnlocked = true;
        }

        if (charName == "deadking")
        {
            EnableCharacter(DeadKingButton, DeadKingAvatar, cub.isDeadKingUnlocked);
            CharacterUnlockBools.instance.isDeadKingUnlocked = true;
        }

        if (charName == "bootoshi")
        {
            EnableCharacter(BootoshiButton, BootoshiAvatar, cub.isBootoshiUnlocked);
            CharacterUnlockBools.instance.isBootoshiUnlocked = true;
        }
    }

    public void DisableAllCharacters()
    {
        if (!cub.isPottedPUnlocked)
        {
            DisableCharacter(PottedPButton, PottedPAvatar);
        }
        if (!cub.isFamousFoxFedUnlocked)
        {
            DisableCharacter(FamousFoxFedButton, FamousFoxFedAvatar);
        }
        if (!cub.isTheHiddenUnlocked)
        {
            DisableCharacter(TheHiddenButton, TheHiddenAvatar);
        }
        if (!cub.isAlphaPharaohUnlocked)
        {
            DisableCharacter(AlphaPharaohButton, AlphaPharaohAvatar);
        }
        if (!cub.isBVDCATUnlocked)
        {
            DisableCharacter(BVDCATButton, BVDCATAvatar);
        }
        if (!cub.isGhostKidUnlocked)
        {
            DisableCharacter(GhostKidButton, GhostKidAvatar);
        }
        if (!cub.isTheImmortalUnlocked)
        {
            DisableCharacter(TheImmortalButton, TheImmortalAvatar);
        }
        if (!cub.isNekozumaUnlocked)
        {
            DisableCharacter(NekozumaButton, NekozumaAvatar);
        }
        if (!cub.isThePixelDudeUnlocked)
        {
            DisableCharacter(ThePixelDudeButton, ThePixelDudeAvatar);
        }
        if (!cub.isBTCMachineUnlocked)
        {
            DisableCharacter(BTCMachineButton, BTCMachineAvatar);
        }
        if (!cub.isOrdinalRabbitUnlocked)
        {
            DisableCharacter(OrdinalRabbitButton, OrdinalRabbitAvatar);
        }
        if (!cub.isSatoshiShellzUnlocked)
        {
            DisableCharacter(SatoshiShellzButton, SatoshiShellzAvatar);
        }
        if (!cub.isDogeCapitalUnlocked)
        {
            DisableCharacter(DogeCapitalButton, DogeCapitalAvatar);
        }
        if (!cub.isDeadKingUnlocked)
        {
            DisableCharacter(DeadKingButton, DeadKingAvatar);
        }
        if (!cub.isBootoshiUnlocked)
        {
            DisableCharacter(BootoshiButton, BootoshiAvatar);
        }
    }

    public void DisableCharacter(Button characterButton, Image characterAvatar)
    {
        characterButton.interactable = false;
        characterAvatar.color = new Color(characterAvatar.color.r, characterAvatar.color.g, characterAvatar.color.b, 0.1f);
    }

    public void EnableCharacter(Button characterButton, Image characterAvatar, bool characterUnlock)
    {
        cub.SetBool(characterUnlock, true);
        characterButton.interactable = true;
        characterAvatar.color = new Color(characterAvatar.color.r, characterAvatar.color.g, characterAvatar.color.b, 1f);
    }
}
