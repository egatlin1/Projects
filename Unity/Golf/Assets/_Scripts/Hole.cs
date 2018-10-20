using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
   [Tooltip("The name of the next level after the player finishes this hole")]
   public string nextLevel;

   public float timeBrforeNextLevel = 5f;

   SceneController sceneController;

   private void Awake ( )
   {
      sceneController = FindObjectOfType<SceneController>();
   }

   private void OnTriggerEnter ( Collider other )
   {
      if (other.tag == "GolfBall")
      {
         Debug.Log("in the hole!!!!!");
         Invoke("RoundOver", timeBrforeNextLevel);
         other.GetComponent<GolfBallController>().canReset = false;
      }
   }

   private void RoundOver ( )
   {
      sceneController.LoadLevel(nextLevel);
   }

}
