using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnlockBools : MonoBehaviour
{
    public static CharacterUnlockBools instance;

    public bool firstCheck;

    [Header("Unlock Status")]
    public bool isPottedPUnlocked;
    public bool isFamousFoxFedUnlocked;
    public bool isTheHiddenUnlocked;
    public bool isAlphaPharaohUnlocked;
    public bool isBVDCATUnlocked;
    public bool isGhostKidUnlocked;
    public bool isTheImmortalUnlocked;
    public bool isNekozumaUnlocked;
    public bool isThePixelDudeUnlocked;
    public bool isBTCMachineUnlocked;
    public bool isOrdinalRabbitUnlocked;
    public bool isSatoshiShellzUnlocked;
    public bool isDogeCapitalUnlocked;
    public bool isDeadKingUnlocked;
    public bool isBootoshiUnlocked;

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

    public void SetBool(bool boolName, bool output)
    {
        boolName = output;
    }

    public void LockAll()
    {
        isPottedPUnlocked = false;
        isFamousFoxFedUnlocked = false;
        isTheHiddenUnlocked = false;
        isAlphaPharaohUnlocked = false;
        isBVDCATUnlocked = false;
        isGhostKidUnlocked = false;
        isTheImmortalUnlocked = false;
        isNekozumaUnlocked = false;
        isThePixelDudeUnlocked = false;
        isBTCMachineUnlocked = false;
        isOrdinalRabbitUnlocked = false;
        isSatoshiShellzUnlocked = false;
        isDogeCapitalUnlocked = false;
        isDeadKingUnlocked = false;
        isBootoshiUnlocked = false;
    }
}
