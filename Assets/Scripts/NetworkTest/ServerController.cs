using UnityEngine;
using KyleDulce.SocketIo;
using TMPro;
using System.Collections;

public class ServerController : MonoBehaviour
{
    public static ServerController instance;

    Socket s;
    bool isReady = false;
    bool gameIsOn = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        s = SocketIo.establishSocketConnection("ws://localhost:3000");
        s.connect();
        s.on("playerConnect", OnConnect);
        s.on("playerReady", OnPlayerReady);
        s.on("bothPlayersReady", OnBothPlayersReady);
        s.on("updatePositions", OnUpdatePositions);
        s.on("gameStart", OnGameStart);
        s.on("youLose", YouLose);
        s.on("youWin", YouWin);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendReady();
        }
    }

    void OnConnect(string e)
    {
        Debug.Log("Connected to server, your ID: " + e);
    }

    void OnPlayerReady(string e)
    {
        Debug.Log("Player is ready: " + e);
    }

    void OnBothPlayersReady(string e)
    {
        Debug.Log("Player is ready: " + e);
    }

    void OnUpdatePositions(string e)
    {
        Debug.Log("Player is ready: " + e);
    }

    void SetRandomSeed()
    {
        string seed = Random.Range(0, 99999999).ToString();
        // emit to clients
    }

    void OnPlayerPosition(string e)
    {
        Debug.Log("Received player position: " + e);

        Vector3 playerPos = JsonUtility.FromJson<Vector3>(e);

        GameObject enemyObject = GameObject.Find("EnemyCharacter");
        if (enemyObject != null)
        {
            enemyObject.transform.position = playerPos;
        }
    }

    void OnGameStart(string e)
    {
        Debug.Log("Game started");
        gameIsOn = true;

        LevelManager.instance.StartGameButton();
        StartCoroutine(SendPosRepeatedly(0.3f));
    }

    public void SendReady()
    {
        if (!isReady)
        {
            isReady = true;
            s.emit("ready", "ready");
        }
    }

    public void SendPosition(Vector3 position)
    {
        s.emit("playerPosition", JsonUtility.ToJson(position));
    }

    IEnumerator SendPosRepeatedly(float rate)
    {
        if (gameIsOn)
        {
            SendPosition(transform.position);
            yield return new WaitForSeconds(rate);
            StartCoroutine(SendPosRepeatedly(rate));
        }
    }

    public void GameEnded()
    {
        gameIsOn = false;
        s.emit("gameEnded", "end");
    }

    void YouLose(string e)
    {
        Debug.Log("Lose!");
        GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>().text = "you lose!";
    }

    void YouWin(string e)
    {
        Debug.Log("Win!");
        PlayerHealth.instance.StopGame(false);
        GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>().text = "you win!";
    }

    private void OnApplicationQuit()
    {
        s.emit("disconnect", "disconnect");
    }
}