using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{

   public int par = 0;
   private int hits = 0;

   public Text text;

   // Use this for initialization
   void Start ( )
   {
      SetText();
   }

   private void SetText ( )
   {
      text.text = "Par " + par + ": Stroke " + hits;
   }

   public void AddHit ( )
   {
      hits++;
      SetText();
      if ( hits > par )
      {
         text.color = Color.red;
      }
   }


}
