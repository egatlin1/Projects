using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
   public AudioClip[] musicClips;

   private AudioSource audioSource;

   int lastSong = -1;
   // Use this for initialization
   void Awake ( )
   {
      DontDestroyOnLoad(this.gameObject);


      audioSource = GetComponent<AudioSource>();

      PickSong();
   }

   private void PickSong ( )
   {
      if (!audioSource.isPlaying)
      {
         if (musicClips.Length > 1)
         {
            int rand = lastSong;
            while ( rand == lastSong )
               rand = Random.Range(0, musicClips.Length);
            lastSong = rand;
            audioSource.clip = musicClips[lastSong];
            audioSource.Play();

         }
         else if ( musicClips.Length == 0)
         {
            // Do nothing
         }
         else 
            audioSource.clip = musicClips[0]; ;
      }
   }



   // Update is called once per frame
   void Update ( )
   {
      PickSong();
   }
}
