using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCameraPos : MonoBehaviour
{
   [Tooltip("The postion the main camera will be placed when the golfball enters into this collider")]
   public Transform cameraPosition;

   Camera main;

   private void Awake ( )
   {
      main = Camera.main;
   }


   private void OnTriggerEnter ( Collider other )
   {
      if ( other.tag == "GolfBall")
         main.transform.position = cameraPosition.position;
      
   }


}
