using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    SceneController sceneController;

    [Tooltip("Name of the next scene to load after this level is won")] public string nextScene;


    private int numOfPlatforms = 0, numOfActivatedPlatforms = 0;

    public void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        if (!sceneController)
            Debug.LogWarning("No SceneController found");
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfActivatedPlatforms == numOfPlatforms)
        {
            Debug.Log("You win!!!!!!");
            LevelWon(nextScene);
        }
    }

    public void LevelLost ( )
    {
        //TODO: make trasition smoother
        Debug.Log("Level Lost");
        sceneController.reloadCurrentScene();
    }
    
    public void LevelWon ( string nextLevel )
    {
        sceneController.loadScene(nextLevel);
    }


    public void RegisterPlatform ( )
    {
        numOfPlatforms++;
    }

    public void PlatformActivated ( )
    {
        numOfActivatedPlatforms++;
    }
    public void PlatformDeactivated ( )
    {
        numOfActivatedPlatforms--;
    }
}
