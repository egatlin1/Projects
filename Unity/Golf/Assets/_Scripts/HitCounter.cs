using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{

   public int par = 0;
   private int hits = 0;
   private int maxHits = 0;

   public Text text;
   public Text result;


   // Use this for initialization
   void Start ( )
   {
      SetText();
      maxHits = par + 5;
      result.text = "";


      
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


   public void ShowResults ( )
   {

      if (hits == 1)
         result.text = "Hole In One!";
      else
         switch ( hits - par )
         {
            case -4:
               result.text = "Condor!";
               break;
            case -3:
               result.text = "Albatross!";
               break;
            case -2:
               result.text = "Eagle!";
               break;
            case -1:
               result.text = "Birdie";
               break;
            case 0:
               result.text = "Par!";
               break;
            case 1:
               result.text = "Bogey";
               break;
            case 2:
               result.text = "Double-Bogey";
               break;
            case 3:
               result.text = "Tripple-Bogiy";
               break;

            default:
               if (hits - par < -4)
                  result.text = "Condor!";
               else
                  result.text = (hits - par) + "-Over-Par";

               break;

         }
   }

   public bool MaxHits ( )
   {
      if ( hits == maxHits )
      {
         result.text = "Stroke out";
         Invoke("ResetLevel", 3);
         return true;
      }
      else
         return false;
   }

   private void ResetLevel ( )
   {
      FindObjectOfType<SceneController>().ReloadCurrentLevel();
   }
}
