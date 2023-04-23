using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class GuestLogin : MonoBehaviour
{
    public static GuestLogin instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }
}