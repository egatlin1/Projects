using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

   public Teleporter otherTeleporter;

   // Use this for initialization
   void Start ( )
   {

   }

   // Update is called once per frame
   void Update ( )
   {

   }


   private void OnTriggerEnter2D ( Collider2D other )
   {
      PlayerController player = other.GetComponent<PlayerController>();

      if (player && player.TeleportState())
      {
         player.gameObject.transform.position = otherTeleporter.transform.position;

         player.changeTeleportState();
      }
      else if ( player )
      {
         player.changeTeleportState();
      }
   }
}
