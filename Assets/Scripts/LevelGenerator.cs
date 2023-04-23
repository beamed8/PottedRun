using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float playerDistance = 10f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform testPlatform;
    [SerializeField] private List<Transform> levelPartsEasyList;
    [SerializeField] private List<Transform> levelPartsMediumList;
    [SerializeField] private List<Transform> levelPartsHardList;
    [SerializeField] private List<Transform> levelPartsExtremeList;
    [SerializeField] private PlayerMovement player;

    [Header("Difficulty Limits")]
    public int easy = 5;
    public int medium = 15;
    public int hard = 25;
    public int extreme = 35;
    public int nightmare1 = 45;
    public int nightmare2 = 55;
    public int nightmare3 = 65;

    private enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Extreme,
        Nigthmare1,
        Nigthmare2,
        Nigthmare3,
    }

    private Vector3 lastEndPosition;

    public int levelPartsSpawned;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        if (testPlatform != null)
        {
            Debug.Log("Test platform.");
        }

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < playerDistance)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        List<Transform> difficultyLevelPartList;
        switch (GetDifficulty())
        {
            default:
            case Difficulty.Easy: difficultyLevelPartList = levelPartsEasyList; break;
            case Difficulty.Medium: difficultyLevelPartList = levelPartsMediumList; break;
            case Difficulty.Hard: difficultyLevelPartList = levelPartsHardList; break;
            case Difficulty.Extreme: difficultyLevelPartList = levelPartsExtremeList; break;
            case Difficulty.Nigthmare1: difficultyLevelPartList = levelPartsExtremeList; break;
            case Difficulty.Nigthmare2: difficultyLevelPartList = levelPartsExtremeList; break;
            case Difficulty.Nigthmare3: difficultyLevelPartList = levelPartsExtremeList; break;
        }

        SetPlayerSpeed();

        Transform chosenLevelPart = difficultyLevelPartList[Random.Range(0, difficultyLevelPartList.Count)];

        if (testPlatform != null)
        {
            chosenLevelPart = testPlatform;
        }

        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;

        levelPartsSpawned++;

        BackgroundChanger.instance.SetCurrentPlatforms();
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private Difficulty GetDifficulty()
    {
        if (levelPartsSpawned >= 35) return Difficulty.Nigthmare3;
        if (levelPartsSpawned >= 25) return Difficulty.Nigthmare2;
        if (levelPartsSpawned >= 20) return Difficulty.Nigthmare1;
        if (levelPartsSpawned >= 15) return Difficulty.Extreme;
        if (levelPartsSpawned >= 10) return Difficulty.Hard;
        if (levelPartsSpawned >= 5) return Difficulty.Medium;
        return Difficulty.Easy;
    }

    private void SetPlayerSpeed()
    {
        switch (GetDifficulty())
        {
            default:
            case Difficulty.Easy: player.moveSpeed = 2.5f; break;
            case Difficulty.Medium: player.moveSpeed = 2.8f; break;
            case Difficulty.Hard: player.moveSpeed = 3.3f; break;
            case Difficulty.Extreme: player.moveSpeed = 3.7f; break;
            case Difficulty.Nigthmare1: player.moveSpeed = 4.1f; break;
            case Difficulty.Nigthmare2: player.moveSpeed = 4.7f; break;
            case Difficulty.Nigthmare3: player.moveSpeed = 5.4f; break;
        }
    }
}
