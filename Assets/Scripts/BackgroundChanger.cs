using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public static BackgroundChanger instance;
    public Season currentSeason;
    public Season previousSeason;
    public bool isForcedBackground;

    [Header("Layers")]
    public SpriteRenderer[] layersTwo;
    public SpriteRenderer[] layersThree;
    public SpriteRenderer[] layersFour;

    [Header("Backgrounds")]
    public Sprite dummyBackground;
    public GameObject seasonBackgrounds;

    [Header("Dead King")]
    public GameObject deadkingBackgrounds;

    [Header("Bootoshi")]
    public GameObject bootoshiBackgrounds;

    [Header("Winter")]
    public Sprite winterNumberTwo;
    public Sprite winterNumberThree;
    public Sprite winterNumberFour;
    [Header("Autumn")]
    public Sprite autumnNumberTwo;
    public Sprite autumnNumberThree;
    public Sprite autumnNumberFour;
    [Header("Summer")]
    public Sprite summerNumberTwo;
    public Sprite summerNumberThree;
    public Sprite summerNumberFour;
    [Header("Spring")]
    public Sprite springNumberTwo;
    public Sprite springNumberThree;
    public Sprite springNumberFour;

    [Header("Particles")]
    public GameObject summerParticles;
    public GameObject autumnParticles;
    public GameObject winterParticles;
    public GameObject springParticles;
    public GameObject deadkingParticles;

    [Header("Obstacles")]
    [Header("Winter")]
    public Sprite winterSmallObstacle;
    public Sprite winterBigObstacle;
    [Header("Autumn")]
    public Sprite autumnSmallObstacle;
    public Sprite autumnBigObstacle;
    [Header("Summer")]
    public Sprite summerSmallObstacle;
    public Sprite summerBigObstacle;
    [Header("Spring")]
    public Sprite springSmallObstacle;
    public Sprite springBigObstacle;
    [Header("Dead King")]
    public Sprite deadkingSmallObstacle;
    public Sprite deadkingBigObstacle;
    [Header("Bootoshi")]
    public Sprite bootoshiSmallObstacle;
    public Sprite bootoshiBigObstacle;

    [Header("Platforms")]
    [Header("Winter")]
    public Sprite winter1x1;
    public Sprite winter1x2;
    public Sprite winter1x3;
    public Sprite winter1x4;
    public Sprite winter1x5;
    public Sprite winter1x6;
    public Sprite winter1x7;
    public Sprite winter1x8;
    public Sprite winter1x9;
    public Sprite winter1x10;
    [Header("Summer")]
    public Sprite summer1x1;
    public Sprite summer1x2;
    public Sprite summer1x3;
    public Sprite summer1x4;
    public Sprite summer1x5;
    public Sprite summer1x6;
    public Sprite summer1x7;
    public Sprite summer1x8;
    public Sprite summer1x9;
    public Sprite summer1x10;
    [Header("Autumn")]
    public Sprite autumn1x1;
    public Sprite autumn1x2;
    public Sprite autumn1x3;
    public Sprite autumn1x4;
    public Sprite autumn1x5;
    public Sprite autumn1x6;
    public Sprite autumn1x7;
    public Sprite autumn1x8;
    public Sprite autumn1x9;
    public Sprite autumn1x10;
    [Header("Spring")]
    public Sprite spring1x1;
    public Sprite spring1x2;
    public Sprite spring1x3;
    public Sprite spring1x4;
    public Sprite spring1x5;
    public Sprite spring1x6;
    public Sprite spring1x7;
    public Sprite spring1x8;
    public Sprite spring1x9;
    public Sprite spring1x10;
    [Header("Dead King")]
    public Sprite deadking1x1;
    public Sprite deadking1x2;
    public Sprite deadking1x3;
    public Sprite deadking1x4;
    public Sprite deadking1x5;
    public Sprite deadking1x6;
    public Sprite deadking1x7;
    public Sprite deadking1x8;
    public Sprite deadking1x9;
    public Sprite deadking1x10;
    [Header("Bootoshi")]
    public Sprite bootoshi1x1;
    public Sprite bootoshi1x2;
    public Sprite bootoshi1x3;
    public Sprite bootoshi1x4;
    public Sprite bootoshi1x5;
    public Sprite bootoshi1x6;
    public Sprite bootoshi1x7;
    public Sprite bootoshi1x8;
    public Sprite bootoshi1x9;
    public Sprite bootoshi1x10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!isForcedBackground)
        {
            SetRandomSeason();
            previousSeason = currentSeason;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     SetRandomSeason();
        // }
    }

    public void ChangeSeason(Season season)
    {
        // if (currentSeason != Season.DeadKing || currentSeason != Season.Bootoshi)
        // {
        //     previousSeason = currentSeason;
        // }
        currentSeason = season;


        if (season == Season.Winter)
        {
            foreach (SpriteRenderer layerTwo in layersTwo)
            {
                layerTwo.sprite = winterNumberTwo;
            }

            foreach (SpriteRenderer layerThree in layersThree)
            {
                layerThree.sprite = winterNumberThree;
            }

            foreach (SpriteRenderer layerFour in layersFour)
            {
                layerFour.sprite = winterNumberFour;
            }
        }

        if (season == Season.Summer)
        {
            foreach (SpriteRenderer layerTwo in layersTwo)
            {

                layerTwo.sprite = summerNumberTwo;

            }

            foreach (SpriteRenderer layerThree in layersThree)
            {

                layerThree.sprite = summerNumberThree;

            }
            foreach (SpriteRenderer layerFour in layersFour)
            {

                layerFour.sprite = summerNumberFour;

            }
        }

        if (season == Season.Autumn)
        {
            foreach (SpriteRenderer layerTwo in layersTwo)
            {
                layerTwo.sprite = autumnNumberTwo;
            }

            foreach (SpriteRenderer layerThree in layersThree)
            {
                layerThree.sprite = autumnNumberThree;
            }

            foreach (SpriteRenderer layerFour in layersFour)
            {
                layerFour.sprite = autumnNumberFour;
            }
        }

        if (season == Season.Spring)
        {
            foreach (SpriteRenderer layerTwo in layersTwo)
            {
                layerTwo.sprite = springNumberTwo;
            }

            foreach (SpriteRenderer layerThree in layersThree)
            {
                layerThree.sprite = springNumberThree;
            }

            foreach (SpriteRenderer layerFour in layersFour)
            {
                layerFour.sprite = springNumberFour;
            }
        }

        if (season == Season.DeadKing)
        {
            deadkingBackgrounds.SetActive(true);
            bootoshiBackgrounds.SetActive(false);
            seasonBackgrounds.SetActive(false);
        }

        if (season == Season.Bootoshi)
        {
            bootoshiBackgrounds.SetActive(true);
            deadkingBackgrounds.SetActive(false);
            seasonBackgrounds.SetActive(false);
        }

        SetPlatforms(season);
        SetObstacles(season);
        SetParticleEffect(season);
        HandleBGM();
    }

    public Season GetCurrentSeason()
    {
        return currentSeason;
    }

    public void SetCurrentPlatforms()
    {
        SetPlatforms(currentSeason);
        SetObstacles(currentSeason);
    }

    public void SetRandomSeason()
    {
        Season randomSeason = (Season)Random.Range(0, 4);
        ChangeSeason(randomSeason);
    }

    public void SetParticleEffect(Season season)
    {
        if (season == Season.Winter)
        {
            winterParticles.SetActive(true);
            summerParticles.SetActive(false);
            springParticles.SetActive(false);
            autumnParticles.SetActive(false);
        }
        if (season == Season.Autumn)
        {
            winterParticles.SetActive(false);
            summerParticles.SetActive(false);
            springParticles.SetActive(false);
            autumnParticles.SetActive(true);
        }
        if (season == Season.Summer)
        {
            winterParticles.SetActive(false);
            summerParticles.SetActive(true);
            springParticles.SetActive(false);
            autumnParticles.SetActive(false);
        }
        if (season == Season.Spring)
        {
            winterParticles.SetActive(false);
            summerParticles.SetActive(false);
            springParticles.SetActive(true);
            autumnParticles.SetActive(false);
        }
        if (season == Season.DeadKing)
        {
            winterParticles.SetActive(false);
            summerParticles.SetActive(false);
            springParticles.SetActive(false);
            autumnParticles.SetActive(false);
        }

        if (season == Season.Bootoshi)
        {
            winterParticles.SetActive(false);
            summerParticles.SetActive(false);
            springParticles.SetActive(true);
            autumnParticles.SetActive(false);
        }
    }

    private void SetObstacles(Season season)
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        if (season == Season.Winter)
        {
            foreach (GameObject obstacle in obstacles)
            {
                Sprite obstacleSprite = obstacle.GetComponent<SpriteRenderer>().sprite;
                if (obstacleSprite.name == "Big")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = winterBigObstacle;
                }
                if (obstacleSprite.name == "Small")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = winterSmallObstacle;
                }
            }
        }

        if (season == Season.Autumn)
        {
            foreach (GameObject obstacle in obstacles)
            {
                Sprite obstacleSprite = obstacle.GetComponent<SpriteRenderer>().sprite;
                if (obstacleSprite.name == "Big")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = autumnBigObstacle;
                }
                if (obstacleSprite.name == "Small")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = autumnSmallObstacle;
                }
            }
        }
        if (season == Season.Summer)
        {
            foreach (GameObject obstacle in obstacles)
            {
                Sprite obstacleSprite = obstacle.GetComponent<SpriteRenderer>().sprite;
                if (obstacleSprite.name == "Big")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = summerBigObstacle;
                }
                if (obstacleSprite.name == "Small")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = summerSmallObstacle;
                }
            }
        }
        if (season == Season.Spring)
        {
            foreach (GameObject obstacle in obstacles)
            {
                Sprite obstacleSprite = obstacle.GetComponent<SpriteRenderer>().sprite;
                if (obstacleSprite.name == "Big")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = springBigObstacle;
                }
                if (obstacleSprite.name == "Small")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = springSmallObstacle;
                }
            }
        }

        if (season == Season.DeadKing)
        {
            foreach (GameObject obstacle in obstacles)
            {
                Sprite obstacleSprite = obstacle.GetComponent<SpriteRenderer>().sprite;
                if (obstacleSprite.name == "Big")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = deadkingBigObstacle;
                }
                if (obstacleSprite.name == "Small")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = deadkingSmallObstacle;
                }
            }
        }

        if (season == Season.Bootoshi)
        {
            foreach (GameObject obstacle in obstacles)
            {
                Sprite obstacleSprite = obstacle.GetComponent<SpriteRenderer>().sprite;
                if (obstacleSprite.name == "Big")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = bootoshiBigObstacle;
                }
                if (obstacleSprite.name == "Small")
                {
                    obstacle.GetComponent<SpriteRenderer>().sprite = bootoshiSmallObstacle;
                }
            }
        }

        // Debug.Log("Set obstacles to season :" + season);
    }

    private void SetPlatforms(Season season)
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        if (season == Season.Winter)
        {
            foreach (GameObject platform in platforms)
            {
                Sprite platformSprite = platform.GetComponent<SpriteRenderer>().sprite;
                if (platformSprite.name == "1x1")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x1;
                }
                if (platformSprite.name == "1x2")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x2;
                }
                if (platformSprite.name == "1x3")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x3;
                }
                if (platformSprite.name == "1x4")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x4;
                }
                if (platformSprite.name == "1x5")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x5;
                }
                if (platformSprite.name == "1x6")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x6;
                }
                if (platformSprite.name == "1x7")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x7;
                }
                if (platformSprite.name == "1x8")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x8;
                }
                if (platformSprite.name == "1x9")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x9;
                }
                if (platformSprite.name == "1x10")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = winter1x10;
                }
            }
        }

        if (season == Season.Summer)
        {
            foreach (GameObject platform in platforms)
            {
                Sprite platformSprite = platform.GetComponent<SpriteRenderer>().sprite;
                if (platformSprite.name == "1x1")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x1;
                }
                if (platformSprite.name == "1x2")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x2;
                }
                if (platformSprite.name == "1x3")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x3;
                }
                if (platformSprite.name == "1x4")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x4;
                }
                if (platformSprite.name == "1x5")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x5;
                }
                if (platformSprite.name == "1x6")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x6;
                }
                if (platformSprite.name == "1x7")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x7;
                }
                if (platformSprite.name == "1x8")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x8;
                }
                if (platformSprite.name == "1x9")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x9;
                }
                if (platformSprite.name == "1x10")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = summer1x10;
                }
            }
        }

        if (season == Season.Autumn)
        {
            foreach (GameObject platform in platforms)
            {
                Sprite platformSprite = platform.GetComponent<SpriteRenderer>().sprite;
                if (platformSprite.name == "1x1")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x1;
                }
                if (platformSprite.name == "1x2")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x2;
                }
                if (platformSprite.name == "1x3")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x3;
                }
                if (platformSprite.name == "1x4")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x4;
                }
                if (platformSprite.name == "1x5")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x5;
                }
                if (platformSprite.name == "1x6")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x6;
                }
                if (platformSprite.name == "1x7")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x7;
                }
                if (platformSprite.name == "1x8")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x8;
                }
                if (platformSprite.name == "1x9")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x9;
                }
                if (platformSprite.name == "1x10")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = autumn1x10;
                }
            }
        }

        if (season == Season.Spring)
        {
            foreach (GameObject platform in platforms)
            {
                Sprite platformSprite = platform.GetComponent<SpriteRenderer>().sprite;
                if (platformSprite.name == "1x1")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x1;
                }
                if (platformSprite.name == "1x2")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x2;
                }
                if (platformSprite.name == "1x3")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x3;
                }
                if (platformSprite.name == "1x4")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x4;
                }
                if (platformSprite.name == "1x5")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x5;
                }
                if (platformSprite.name == "1x6")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x6;
                }
                if (platformSprite.name == "1x7")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x7;
                }
                if (platformSprite.name == "1x8")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x8;
                }
                if (platformSprite.name == "1x9")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x9;
                }
                if (platformSprite.name == "1x10")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = spring1x10;
                }
            }
        }

        if (season == Season.DeadKing)
        {
            foreach (GameObject platform in platforms)
            {
                Sprite platformSprite = platform.GetComponent<SpriteRenderer>().sprite;
                if (platformSprite.name == "1x1")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x1;
                }
                if (platformSprite.name == "1x2")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x2;
                }
                if (platformSprite.name == "1x3")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x3;
                }
                if (platformSprite.name == "1x4")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x4;
                }
                if (platformSprite.name == "1x5")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x5;
                }
                if (platformSprite.name == "1x6")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x6;
                }
                if (platformSprite.name == "1x7")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x7;
                }
                if (platformSprite.name == "1x8")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x8;
                }
                if (platformSprite.name == "1x9")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x9;
                }
                if (platformSprite.name == "1x10")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = deadking1x10;
                }
            }
        }

        if (season == Season.Bootoshi)
        {
            foreach (GameObject platform in platforms)
            {
                Sprite platformSprite = platform.GetComponent<SpriteRenderer>().sprite;
                if (platformSprite.name == "1x1")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x1;
                }
                if (platformSprite.name == "1x2")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x2;
                }
                if (platformSprite.name == "1x3")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x3;
                }
                if (platformSprite.name == "1x4")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x4;
                }
                if (platformSprite.name == "1x5")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x5;
                }
                if (platformSprite.name == "1x6")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x6;
                }
                if (platformSprite.name == "1x7")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x7;
                }
                if (platformSprite.name == "1x8")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x8;
                }
                if (platformSprite.name == "1x9")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x9;
                }
                if (platformSprite.name == "1x10")
                {
                    platform.GetComponent<SpriteRenderer>().sprite = bootoshi1x10;
                }
            }
        }
    }

    private void HandleBGM()
    {
        if (currentSeason == Season.Winter)
        {
            SoundManager.instance.ChangeMusic(SoundManager.instance.winterMusic);
        }

        if (currentSeason == Season.Autumn)
        {
            SoundManager.instance.ChangeMusic(SoundManager.instance.autumnMusic);
        }

        if (currentSeason == Season.Summer)
        {
            SoundManager.instance.ChangeMusic(SoundManager.instance.summerMusic);
        }

        if (currentSeason == Season.Spring)
        {
            SoundManager.instance.ChangeMusic(SoundManager.instance.springMusic);
        }

        if (currentSeason == Season.DeadKing)
        {
            SoundManager.instance.ChangeMusic(SoundManager.instance.deadkingMusic);
        }

        if (currentSeason == Season.Bootoshi)
        {
            SoundManager.instance.ChangeMusic(SoundManager.instance.bootoshiMusic);
        }
    }

    public void DeadKingSetting()
    {
        isForcedBackground = true;
        ChangeSeason(Season.DeadKing);
        SetBackground();
        HandleBGM();
    }

    public void BootoshiSetting()
    {
        isForcedBackground = true;
        ChangeSeason(Season.Bootoshi);
        SetBackground();
        HandleBGM();
    }

    public void SetBackground()
    {
        if (!isForcedBackground)
        {
            seasonBackgrounds.SetActive(true);
            deadkingBackgrounds.SetActive(false);
            bootoshiBackgrounds.SetActive(false);
            ChangeSeason(previousSeason);
            // SetObstacles(previousSeason);
        }
    }
}

public enum Season
{
    Winter,
    Spring,
    Autumn,
    Summer,
    DeadKing,
    Bootoshi
}
