using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
   public static bool s_IsPlaying = true;

   public GameObject pauseScreen;

   [Tooltip("Name of the next scene to load after this level is won")] public string nextScene;
   [Tooltip("Seconds until the the next level loads after current level has been won")] public float loadDelay = 2.5f;

   SceneController sceneController;

   private int numOfPlatforms = 0, numOfActivatedPlatforms = 0;

   public void Awake ( )
   {
      EventHandler.s_IsPlaying = true;
      Time.timeScale = 1f;
      sceneController = FindObjectOfType<SceneController>();
      if (!sceneController)
         Debug.LogWarning("No SceneController found");
      if (!pauseScreen)
         Debug.LogWarning("pauseScreen not attached to EventHandler");

      pauseScreen.SetActive(false);

   }

   // Update is called once per frame
   void Update ( )
   {
      if (numOfActivatedPlatforms == numOfPlatforms)
      {
         EventHandler.s_IsPlaying = false;

         Invoke("LevelWon", loadDelay);
      }

      if (Input.GetKeyDown(KeyCode.Escape))
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

   public void LevelWon ( )
   {
      sceneController.loadScene(nextScene);
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
