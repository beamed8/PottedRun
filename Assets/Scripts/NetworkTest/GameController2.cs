// using Newtonsoft.Json;
// using UnityEngine;

// public class GameController2 : MonoBehaviour
// {
//     [SerializeField] private GameObject player1;
//     [SerializeField] private GameObject player2;

//     [SerializeField] private GameObject menuManager;
//     [SerializeField] private GameObject soundManager;
//     [SerializeField] private GameObject effectsManager;

//     [SerializeField] private float lerpSpeed = 0.5f;

//     private NetworkController2 network;
//     private GameData gameData;

//     public string InstanceId { get; set; }

//     private void Awake()
//     {
//         DontDestroyOnLoad(this);

//         network = GetComponent<NetworkController2>();

// #if !UNITY_EDITOR && UNITY_WEBGL
//         Debug.Log("Registering network events");
//         network.DataUpdated += DataUpdated;
//         network.GameOver += GameEnded;
//         network.Intermission += Intermission;
//         network.PositionsUpdated += PositionsUpdated;
//         network.PlayerRegistered += PlayerRegistered;
//         WebGLInput.captureAllKeyboardInput = false;
// #endif
//     }

//     private void Start()
//     {
// #if !UNITY_EDITOR && UNITY_WEBGL
//         Debug.Log("Registering sound manager");
//         network.SoundPlayed += soundManager.GetComponent<SoundController>().PlaySound;
//         network.BallCollision += BallCollision;
//         network.PlayerCollision += PlayerCollision;
// #endif

//         Debug.Log("Registering player controllers");
//         player1.GetComponent<PlayerController>().UpdatePosition += UpdatePosition;
//         player2.GetComponent<PlayerController>().UpdatePosition += UpdatePosition;
//         menuManager.GetComponent<MenuController>().PlayerReady += ReadyPlayer;
//     }

//     private void OnDestroy()
//     {
// #if !UNITY_EDITOR && UNITY_WEBGL
//         Debug.Log("Unregistering network events");
//         network.DataUpdated -= DataUpdated;
//         network.GameOver -= GameEnded;
//         network.Intermission -= Intermission;
//         network.PositionsUpdated -= PositionsUpdated;
//         network.PlayerRegistered -= PlayerRegistered;
//         network.Leave(InstanceId);
//         network.Close();

//         Debug.Log("Unregistering sound manager");
//         network.SoundPlayed -= soundManager.GetComponent<SoundController>().PlaySound;
//         network.BallCollision -= BallCollision;
//         network.PlayerCollision -= PlayerCollision;
// #endif

//         Debug.Log("Unregistering player events");

//         if (player1 != null && player2 != null)
//         {
//             player1.GetComponent<PlayerController>().UpdatePosition -= UpdatePosition;
//             player2.GetComponent<PlayerController>().UpdatePosition -= UpdatePosition;
//         }
//         menuManager.GetComponent<MenuController>().PlayerReady -= ReadyPlayer;
//     }

//     public void GameEnded(string winnerData)
//     {
//         var winner = JsonConvert.DeserializeObject<WinnerData>(winnerData);
//         EndGame(winner);
//     }

//     private void EndGame(WinnerData winner)
//     {
//         menuManager.GetComponent<MenuController>().SetGameStatus(GameStatus.GameOver, winner);
//     }

//     public void ReadyPlayer(string playerKey)
//     {
//         network.Send("playerReady", playerKey);
//         network.PlayerReady();
//     }

//     public void RematchReady(string playerKey)
//     {
//         network.Send("rematchReady", playerKey);
//     }

//     public void RegisterServer(string hostname)
//     {
//         Debug.Log("Registering server");
//         network.Initialize(hostname);
//     }

//     public void RegisterInstance(string instanceId)
//     {
//         this.InstanceId = instanceId;
//         Debug.Log("Initializing game");
//         network.Send("initialize", instanceId);
//     }

//     public void RegisterToken(string token)
//     {
//         Debug.Log("Registering token");
//         network.Send("validate", token);
//     }

//     public void UpdatePosition(string positionData)
//     {
// #if !UNITY_EDITOR && UNITY_WEBGL
//         network.Send("movePaddle", positionData);
// #endif
//     }

//     public void DataUpdated(string data)
//     {
//         gameData = JsonConvert.DeserializeObject<GameData>(data);
//         if (gameData.winner != null)
//             EndGame(gameData.winner);
//         else
//             menuManager.GetComponent<MenuController>().SetGameStatus(gameData.status);
//     }

//     public void PositionsUpdated(string data)
//     {
//         var positions = JsonConvert.DeserializeObject<PositionData>(data);
//         ball.transform.position = Vector2.Lerp(ball.transform.position, positions.ball, lerpSpeed);
//         player1.GetComponent<PlayerController>().UpdatePaddlePosition(positions.player1);
//         player2.GetComponent<PlayerController>().UpdatePaddlePosition(positions.player2);
//     }

//     public void Intermission(string data)
//     {
//         var positions = JsonConvert.DeserializeObject<PositionData>(data);
//         effectsManager.GetComponent<EffectsController>().PlayBallExplosion();
//         effectsManager.GetComponent<EffectsController>().PlayPortal(Vector2.zero);
//         ball.transform.position = Vector2.zero;
//         player1.GetComponent<PlayerController>().UpdatePaddlePosition(positions.player1, true);
//         player2.GetComponent<PlayerController>().UpdatePaddlePosition(positions.player2, true);
//     }

//     public void BallCollision()
//     {
//         effectsManager.GetComponent<EffectsController>().PlayCollision();
//     }

//     public void PlayerCollision(int player)
//     {
//         effectsManager.GetComponent<EffectsController>().PlayCollision(player);
//     }

//     public void PlayerRegistered(string data)
//     {
//         var playerInfo = JsonConvert.DeserializeObject<PlayerInfo>(data);
//         if (gameData.player1.address == playerInfo.address)
//         {
//             player1.GetComponent<PlayerController>().RegisterPlayer(playerInfo.playerKey);
//             Debug.Log("Player 1 registered");
//             menuManager.GetComponent<MenuController>().SetPlayerKey(playerInfo.playerKey);
//         }
//         else if (gameData.player2.address == playerInfo.address)
//         {
//             player2.GetComponent<PlayerController>().RegisterPlayer(playerInfo.playerKey);
//             Debug.Log("Player 2 registered");
//             menuManager.GetComponent<MenuController>().SetPlayerKey(playerInfo.playerKey);
//         }
//     }

//     public GameStatus GetStatus()
//     {
//         return gameData.status;
//     }

//     public bool IsWageredGame()
//     {
//         return gameData.wagered;
//     }
// }