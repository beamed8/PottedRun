using System.Collections;
using UnityEngine;

public class HashlistController : MonoBehaviour
{
    public static HashlistController instance;

    private int totalUnlocked = 0;

    [Header("Hashlist Paths")]
    public TextAsset pottedPHashlistPath;
    public TextAsset fffHashlistPath;
    public TextAsset thehiddenHashlistPath;
    public TextAsset alphapharaohHashlistPath;
    public TextAsset bvdcatHashlistPath;
    public TextAsset ghostkidHashlistPath;
    public TextAsset immortalHashlistPath;
    public TextAsset nekozumaHashlistPath;
    public TextAsset thepixeldudeHashlistPath;
    public TextAsset dogecapitalHashlistPath;
    public TextAsset deadkingsHashlistPath;

    public string[] hashlists;

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
        LoadHashlistPaths();
    }

    private void LoadHashlistPaths()
    {
        pottedPHashlistPath = Resources.Load<TextAsset>("Hashlists/pottedp");
        fffHashlistPath = Resources.Load<TextAsset>("Hashlists/fff");
        thehiddenHashlistPath = Resources.Load<TextAsset>("Hashlists/thehidden");
        alphapharaohHashlistPath = Resources.Load<TextAsset>("Hashlists/alphapharaohs");
        bvdcatHashlistPath = Resources.Load<TextAsset>("Hashlists/bvdcat");
        ghostkidHashlistPath = Resources.Load<TextAsset>("Hashlists/ghostkid");
        // immortalHashlistPath = Resources.Load<TextAsset>("Hashlists/pottedp");
        nekozumaHashlistPath = Resources.Load<TextAsset>("Hashlists/nekozuma");
        thepixeldudeHashlistPath = Resources.Load<TextAsset>("Hashlists/thepixeldude");
        dogecapitalHashlistPath = Resources.Load<TextAsset>("Hashlists/dogecapital");
        deadkingsHashlistPath = Resources.Load<TextAsset>("Hashlists/deadking");
    }

    public void CompareAllHashlists(string hash)
    {
        StartCoroutine(CompareAllHashlistsRoutine(hash));
    }

    public IEnumerator CompareAllHashlistsRoutine(string hash)
    {
        LevelManager.instance.SetWalletText("Collecting token data...");
        Debug.Log("Checking all the hashlists...");


        Debug.Log("Checking Potted P...");
        bool pottedPexists = CompareHash(pottedPHashlistPath, hash);
        if (pottedPexists)
        {
            Debug.Log("Found Potted P! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("pottedp");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("Potted P not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking FFF...");
        bool fffExists = CompareHash(fffHashlistPath, hash);
        if (fffExists)
        {
            Debug.Log("Found FFF! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("fff");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("FFF not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking The Hidden...");
        bool theHiddenExists = CompareHash(thehiddenHashlistPath, hash);
        if (theHiddenExists)
        {
            Debug.Log("Found The Hidden! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("thehidden");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("The Hidden not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking Alpha Pharaoh...");
        bool alphaPharaohExists = CompareHash(alphapharaohHashlistPath, hash);
        if (alphaPharaohExists)
        {
            Debug.Log("Found Alpha Pharaoh! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("alphapharaoh");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("Alpha Pharaoh not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking BVDCAT...");
        bool bvdcatExists = CompareHash(bvdcatHashlistPath, hash);
        if (bvdcatExists)
        {
            Debug.Log("Found BVDCAT! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("bvdcat");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("BVDCAT not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking Ghost Kid...");
        bool ghostkidExists = CompareHash(ghostkidHashlistPath, hash);
        if (ghostkidExists)
        {
            Debug.Log("Found Ghost Kid! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("ghostkid");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("Ghost Kid not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking Nekozuma...");
        bool nekozumaExists = CompareHash(nekozumaHashlistPath, hash);
        if (nekozumaExists)
        {
            Debug.Log("Found Nekozuma! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("nekozuma");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("Nekozuma not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking The Pixel Dude...");
        bool thepixeldudeExists = CompareHash(thepixeldudeHashlistPath, hash);
        if (theHiddenExists)
        {
            Debug.Log("Found The Pixel Dude! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("thepixeldude");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("The Pixel Dude not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking Doge Capital...");
        bool dogecapitalExists = CompareHash(dogecapitalHashlistPath, hash);
        if (dogecapitalExists)
        {
            Debug.Log("Found Doge Capital! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("dogecapital");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("Doge Capital not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Checking Dead King...");
        bool deadkingExists = CompareHash(deadkingsHashlistPath, hash);
        if (deadkingExists)
        {
            Debug.Log("Found Dead King! Unlocking the character...");
            CharacterUnlocker.instance.UnlockCharacter("deadking");
            totalUnlocked++;
            yield break;
        }
        else
        {
            Debug.Log("Dead King not found. Moving on...");
        }
        yield return new WaitForEndOfFrame();


        Debug.Log("Ended.");
        yield return new WaitForSeconds(1);
        Debug.Log("Ended with plus 1sec.");

        if (totalUnlocked == 0)
        {
            LevelManager.instance.SetWalletText("Oh no! You don't have any eligible token for custom characters.");
        }
        if (totalUnlocked == 1)
        {
            LevelManager.instance.SetWalletText("Unlocked <color=orange>" + totalUnlocked + " </color>character!");
        }
        if (totalUnlocked > 1)
        {
            LevelManager.instance.SetWalletText("Unlocked <color=orange>" + totalUnlocked + " </color>characters!");
        }

        LevelManager.instance.EnableCloseWalletButton();
    }

    public bool CompareHash(TextAsset hashlist, string hash)
    {
        string foundHashlist = hashlist.text;

        Hashlist jsonArray = JsonUtility.FromJson<Hashlist>(foundHashlist);

        bool found = false;

        foreach (string str in jsonArray.hashes)
        {
            if (str == hash)
            {
                found = true;
                break;
            }
        }

        if (found)
        {
            Debug.Log("String found!");
            return true;
        }
        else
        {
            Debug.Log("String not found.");
            return false;
        }
    }
}

[System.Serializable]
public class Hashlist
{
    public string[] hashes;
}