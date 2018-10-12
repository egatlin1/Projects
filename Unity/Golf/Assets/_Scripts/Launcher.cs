using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
   public float maxLaunchPower = 1000;

   public float launchPower;

   private ConstantForce force;

   public Slider powerBar;

   // Use this for initialization
   void Awake ( )
   {

      force = GetComponent<ConstantForce>();
      //powerBar = FindObjectOfType<Slider>();


      launchPower = maxLaunchPower * powerBar.value;

      force.relativeForce = new Vector3(0f, 0f, launchPower);
      force.enabled = false;
   }

   public void LaunchGolfBall ( )
   {
      force.enabled = true;
      Invoke("DisableLaunch", .02f);
   }

   private void DisableLaunch ( )
   {
      force.enabled = false;
      
   }


   public void SetLaunchPower ( float newPower )
   {
      maxLaunchPower = newPower;
   }
   
   void Update ( )
   {
      launchPower = maxLaunchPower * powerBar.value;
      force.relativeForce = new Vector3(0f, 0f, launchPower);
   }
}
