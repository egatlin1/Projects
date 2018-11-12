using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   SceneController sceneController;
   // Use this for initialization
   void Awake ( )
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

   public void ExitProgram ( )
   {
      sceneController.ExitGame();
   }
}
