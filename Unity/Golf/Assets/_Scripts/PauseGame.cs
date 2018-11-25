using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
   public static bool s_isPlaying = true;

   public GameObject pauseScreen;

   private SceneController sceneController;
   // Use this for initialization
   void Start( )
   {
      PauseGame.s_isPlaying = true;
      Time.timeScale = 1f;
      sceneController = FindObjectOfType<SceneController>();
   }

   // Update is called once per frame
   void Update ( )
   {
      if ( Input.GetKeyDown( KeyCode.Escape) )
      {
         PlayingState();
      }
   }

   public void PlayingState ( )
   {
      PauseGame.s_isPlaying = !PauseGame.s_isPlaying;
      Time.timeScale = (PauseGame.s_isPlaying) ? 1f : 0f;
      pauseScreen.SetActive(!PauseGame.s_isPlaying);
   }


   public void LoadMenu ( )
   {
      sceneController.LoadLevel("Menu");
   }

   public void RestartLevel ( )
   {
      sceneController.ReloadCurrentLevel();
   }
}
