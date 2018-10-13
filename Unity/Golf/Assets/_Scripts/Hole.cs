using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
   [Tooltip("The name of the next level after the player finishes this hole")]
   public string nextLevel;

   private void OnTriggerEnter ( Collider other )
   {
      if (other.tag == "GolfBall")
      {
         Debug.Log("in the hole!!!!!");
         Invoke("RoundOver", 5f);
      }
   }

   private void RoundOver ( )
   {
      //calls on scene manager to laod the next level
   }

}
