using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
   public static bool s_isPlaying = true;

   public GameObject pauseScreen;
   // Use this for initialization
   void Awake( )
   {
      PauseGame.s_isPlaying = true;
      Time.timeScale = 1f;
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
}
