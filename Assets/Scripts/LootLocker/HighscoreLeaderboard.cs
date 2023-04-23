using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;

public class HighscoreLeaderboard : MonoBehaviour
{
    public TMP_InputField memberID;
    public int playerScore;
    public string leaderboardKey;

    int maxScores = 10;
    public TextMeshProUGUI[] entries;

    public void SubmitScore()
    {
        string characterName = CharacterSelector.instance.GetCurrentCharacterName();

        if (characterName.Length > 14)
        {
            characterName = characterName.Substring(0, 14);
        }
        if (characterName.Length > 0)
        {
            LootLockerSDKManager.SubmitScore(characterName, PlayerScore.instance.GetCurrentScore(), leaderboardKey, (response) =>
            {
                if (response.statusCode == 200)
                {
                    Debug.Log("Successful");
                    ShowScores();
                    LevelManager.instance.ShowLeaderboard();
                }
                else
                {
                    Debug.Log("failed: " + response.Error);
                }
            });
        }
        else
        {
            Debug.Log("player name is empty");
            return;
        }
    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, maxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = (scores[i].rank + ". <color=white>" + scores[i].member_id + "</color> - <color=yellow>" + scores[i].score + "</color>");
                }

                if (scores.Length < maxScores)
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ". " + " - ";
                    }
                }
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }
}