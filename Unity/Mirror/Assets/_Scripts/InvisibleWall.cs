using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
   SpriteRenderer sprite;

   void Awake ( )
   {
      sprite = GetComponent<SpriteRenderer>();
      sprite.enabled = false;
   }


   private void OnCollisionEnter2D ( Collision2D other )
   {
      sprite.enabled = true;
   }
}
