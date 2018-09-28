using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
   [Tooltip("Time in seconds")] public float countDown = 10f;
   public Text timerText;
   EventHandler eventHandler;

   // Use this for initialization
   void Awake ( )
   {
      if (!timerText)
         Debug.LogWarning("No Text element has been attached to CountDownTimer");
      eventHandler = FindObjectOfType<EventHandler>();
      if (!eventHandler)
         Debug.LogWarning("No EventHandler found");

      timerText.text = countDown.ToString("f0");
   }

   // Update is called once per frame
   void Update ( )
   {
      if (EventHandler.s_IsPlaying)
         updateTimer();
   }

   private void updateTimer ( )
   {
      if (countDown > 0)
      {
         countDown -= Time.deltaTime;
         timerText.text = countDown.ToString("f0");
      }
      else
      {
         eventHandler.LevelLost();
      }

      if (timerText.text == "3")
         timerText.color = Color.red;
   }
}
