using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
   public new ParticleSystem particleSystem;

   EventHandler eventHandler;

   private bool isActivated = false;

   // Use this for initialization
   void Awake ( )
   {
      eventHandler = FindObjectOfType<EventHandler>();
      if (!eventHandler)
         Debug.LogWarning("No EventHandler found");
      eventHandler.RegisterPlatform();
   }


   private void OnTriggerEnter2D ( Collider2D other )
   {
      PlayerController player = other.GetComponent<PlayerController>();

      if (player && !isActivated)
      {
         eventHandler.PlatformActivated();
         isActivated = true;
         particleSystem.gameObject.SetActive(true);
      }
   }

   private void OnTriggerExit2D ( Collider2D other )
   {
      PlayerController player = other.GetComponent<PlayerController>();

      if (player && isActivated)
      {
         eventHandler.PlatformDeactivated();
         Debug.Log("Exited");
         isActivated = false;
         particleSystem.gameObject.SetActive(false);
      }
   }
}
