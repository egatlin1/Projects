using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    SceneController sceneController;

    [Tooltip("Name of the next scene to load after this level is won")] public string nextScene;

    public void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        if (!sceneController)
            Debug.LogWarning("No SceneController found");
    }

    // Update is called once per frame
    void Update()
    {
        if (WinPlatform.s_ActivatedWinPlatforms == WinPlatform.s_NumberOfWinPlatforms)
        {
            Debug.Log("You win!!!!!!");
            sceneController.loadScene(nextScene);
        }
    }
}
