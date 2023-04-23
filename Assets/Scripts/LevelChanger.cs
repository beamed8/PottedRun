using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        SceneHandler.instance.ChangeScene(scene);
    }

    public void RestartScene()
    {
        SoundManager.instance.PlayRandomFromList(SoundManager.instance.clickSounds);
        SceneHandler.instance.RestartScene();
    }
}
