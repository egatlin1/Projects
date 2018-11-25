using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   SceneController sceneController;
   // Use this for initialization
   void Start ( )
   {
      sceneController = FindObjectOfType<SceneController>();
   }

   // Update is called once per frame
   void Update ( )
   {

   }

   public void LoadLevel( string name )
   {
      sceneController.LoadLevel(name);
   }

   public void LoadLevelSingle( string name )
   {
      sceneController.LoadLevelOneShot(name);
   }

   public void RestartLevel ( )
   {
      sceneController.ReloadCurrentLevel();
   }

   public void ExitProgram ( )
   {
      sceneController.ExitGame();
   }
}
