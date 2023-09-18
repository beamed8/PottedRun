// using KyleDulce.SocketIo;
// using System;
// using System.Runtime.InteropServices;
// using UnityEngine;

// public class NetworkController2 : MonoBehaviour
// {
//     private Socket socket;

//     public event Action<string> DataUpdated;

//     public event Action<string> Intermission;

//     public event Action<string> GameOver;

//     public event Action<string> PlayerRegistered;

//     public event Action<string> PositionsUpdated;

//     public event Action<SoundType> SoundPlayed;

//     private void Awake()
//     {
//         DontDestroyOnLoad(this);
//     }

//     public void Initialize(string hostname)
//     {
//         if (hostname == null)
//             throw new Exception("Invalid hostname");

//         socket = SocketIo.establishSocketConnection(DarknetSettings.GetServerUrl(hostname));

//         RegisterEvents();
//     }

//     public void Connect()
//     {
//         socket.connect();
//     }

//     public void Close()
//     {
//         if (socket == null)
//             return;

//         socket.disconnect();
//         socket.close();
//     }

//     public void Leave(string instanceId = null)
//     {
//         if (socket == null)
//             return;

//         socket.emit("leave", instanceId);

//         Close();
//     }

//     public void Send(string eventName, string data = null)
//     {
//         if (socket == null)
//             return;

//         socket.emit(eventName, data);
//     }

//     public void PlayerReady()
//     {
// #if !UNITY_EDITOR && UNITY_WEBGL
//         ReadyPlayer();
// #endif
//     }

//     private void ReceivedGameData(string data)
//     {
//         Debug.Log("Received game data");
//         DataUpdated?.Invoke(data);

//         try
//         {
// #if !UNITY_EDITOR && UNITY_WEBGL
//             UpdateGameData(data);
// #endif
//         }
//         catch (Exception ex)
//         {
//             Debug.Log($"Failed to dispatch {ex.Message}");
//             Debug.Log("Game data: " + data);
//         }
//     }

//     private void ReceivedValidationData(string data)
//     {
//         Debug.Log("Received validation data");
//         PlayerRegistered?.Invoke(data);
//     }

//     private void ReceivedUpdatedPositions(string data)
//     {
//         PositionsUpdated?.Invoke(data);
//     }

//     private void ReceivedSoundPlayed(SoundType soundType)
//     {
//         Debug.Log("Received sound trigger");
//         SoundPlayed?.Invoke(soundType);
//     }

//     private void ReceivedGameOver(string winner)
//     {
//         Debug.Log("Received game over - winner " + winner);
//         ReceivedSoundPlayed(SoundType.GameOver);
//         GameOver?.Invoke(winner);
//     }

//     private void ReceivedIntermissionRequest(string data)
//     {
//         Intermission?.Invoke(data);
//     }

//     private void PlayerCollision(string data)
//     {
//         ReceivedSoundPlayed(SoundType.PlayerCollision);

//         try
//         {
// #if !UNITY_EDITOR && UNITY_WEBGL
//             UpdateBallSpeed(data);
// #endif
//         }
//         catch (Exception ex)
//         {
//             Debug.Log($"Failed to dispatch {ex.Message}");
//             Debug.Log("Game data: " + data);
//         }
//     }

//     private void RegisterEvents()
//     {
//         Debug.Log("Registering events");
//         socket.on("gameData", ReceivedGameData);
//         socket.on("validation", ReceivedValidationData);
//         socket.on("collision", (action) => ReceivedSoundPlayed(SoundType.Collision));
//         socket.on("playerCollision", PlayerCollision);
//         socket.on("updatePositions", ReceivedUpdatedPositions);
//         socket.on("playerScored", (action) => ReceivedSoundPlayed(SoundType.PlayerScored));
//         socket.on("intermission", ReceivedIntermissionRequest);
//         socket.on("gameOver", ReceivedGameOver);
//         Debug.Log("Events registered");
//     }

//     [DllImport("__Internal")]
//     private static extern void UpdateGameData(string gameData);

//     [DllImport("__Internal")]
//     private static extern void UpdateBallSpeed(string ballSpeed);

//     [DllImport("__Internal")]
//     private static extern void ReadyPlayer();
// }