using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{

   GameObject[] hands;

   AudioSource sound;

   // Use this for initialization
   void Start ( )
   {
      hands = GameObject.FindGameObjectsWithTag("Hands");
      sound = GetComponent<AudioSource>();


      for ( int ind = 0; ind < hands.Length; ind++ )
      {
         hands[ind].SetActive(false);
      }

   }


   public void StartApplause ( )
   {
      for ( int ind = 0; ind < hands.Length; ind++ )
      {
         hands[ind].SetActive(true);
      }

      sound.Play();
   }


}
