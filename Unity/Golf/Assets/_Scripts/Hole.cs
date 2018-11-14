using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
   [Tooltip("The name of the next level after the player finishes this hole")]
   public string nextLevel;

   public float timeBrforeNextLevel = 5f;

   bool inHole = false;
   public Text text;
   GolfBallController golfball;
   SceneController sceneController;

   private void Awake ( )
   {
      golfball = FindObjectOfType<GolfBallController>();
      sceneController = FindObjectOfType<SceneController>();
   }

   private void Update ( )
   {
      float dist = Vector3.Magnitude(this.transform.position - golfball.transform.position);

      if (inHole)
         text.text = "0.00 M";
      else
         text.text = dist.ToString("F2") + " M";
   }


   private void OnTriggerEnter ( Collider other )
   {
      if (other.tag == "GolfBall")
      {
         Debug.Log("in the hole!!!!!");
         Invoke("RoundOver", timeBrforeNextLevel);
         other.GetComponent<GolfBallController>().canReset = false;
         inHole = true;
      }
   }

   private void RoundOver ( )
   {
      sceneController.LoadLevel(nextLevel);
   }

}
