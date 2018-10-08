using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
   public ParticleSystem m_particleSystem;

   EventHandler eventHandler;
   Animator animator;

   private bool isActivated = false;

   // Use this for initialization
   void Awake ( )
   {
      eventHandler = FindObjectOfType<EventHandler>();
      if (!eventHandler)
         Debug.LogWarning("No EventHandler found");
      eventHandler.RegisterPlatform();
      animator = GetComponent<Animator>();
   }
   

   private void OnTriggerEnter2D ( Collider2D other )
   {
      PlayerController player = other.GetComponent<PlayerController>();

      if (player && !isActivated)
      {
         eventHandler.PlatformActivated();
         isActivated = true;
         animator.SetBool("IsActivated", true);
         m_particleSystem.gameObject.SetActive(true);
      }
   }

   private void OnTriggerExit2D ( Collider2D other )
   {
      PlayerController player = other.GetComponent<PlayerController>();

      if (player && isActivated)
      {
         eventHandler.PlatformDeactivated();
         isActivated = false;
         animator.SetBool("IsActivated", false);
         m_particleSystem.gameObject.SetActive(false);
      }
   }
}
