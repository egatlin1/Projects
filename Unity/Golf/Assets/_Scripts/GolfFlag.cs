using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfFlag : MonoBehaviour
{
   Transform flagPosition;
   public float height;
   // Use this for initialization
   void Awake ( )
   {
      flagPosition = GameObject.FindGameObjectWithTag("Flag").transform;
      transform.position = new Vector3(flagPosition.position.x, height, flagPosition.position.z + 15 ); // total cheat I know, but I couldn't figure out how to offset the flag icon properly
   }

}
