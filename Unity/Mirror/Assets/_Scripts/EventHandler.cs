using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    public GameObject pauseScreen;

    public static bool s_IsPlaying = true;

    SceneController sceneController;

    [Tooltip("Name of the next scene to load after this level is won")] public string nextScene;


    private int numOfPlatforms = 0, numOfActivatedPlatforms = 0;

    public void Awake()
    {
        EventHandler.s_IsPlaying = true;
        sceneController = FindObjectOfType<SceneController>();
        if (!sceneController)
            Debug.LogWarning("No SceneController found");
        if (!pauseScreen)
            Debug.LogWarning("pauseScreen not attached to EventHandler");

        pauseScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (numOfActivatedPlatforms == numOfPlatforms)
        {
            Debug.Log("You win!!!!!!");
            LevelWon(nextScene);
        }

        if ( Input.GetKeyDown(KeyCode.Escape))
        {
            PlayingState();
        }

    }

    public void PlayingState ( )
    {
        EventHandler.s_IsPlaying = !EventHandler.s_IsPlaying;
        pauseScreen.SetActive(!EventHandler.s_IsPlaying);

        Time.timeScale = (EventHandler.s_IsPlaying) ? 1.0f : 0.0f;
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
