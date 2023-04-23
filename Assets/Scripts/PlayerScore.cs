using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;

    [Header("Scores")]
    public int score = 0;

    [Header("References")]
    public TextMeshProUGUI scoreText;
    public Image scoreIcon;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        UpdateUi();
    }

    public void AddPoint(int amount)
    {
        score += amount;
        ScoreEffect(amount);
        UpdateUi();
    }

    private void UpdateUi()
    {
        scoreText.text = score.ToString();
    }

    private void ScoreEffect(int amount)
    {
        if (amount < 5)
        {
            // scoreText.transform.DOShakePosition(1f, 4);
            scoreText.color = Color.yellow;
            scoreText.DOColor(Color.white, 0.5f);
        }
        else
        {
            scoreText.transform.DOShakePosition(1f, 10);
            scoreText.transform.DOPunchScale(scoreText.transform.localScale * 1.1f, 0.5f);
            scoreText.color = Color.red;
            scoreText.DOColor(Color.white, 0.5f);
        }
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
