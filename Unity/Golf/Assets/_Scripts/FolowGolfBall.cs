using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowGolfBall : MonoBehaviour
{
   Transform GolfBallPosition;
   public float height;
   // Use this for initialization
   void Awake ( )
   {
      GolfBallPosition = FindObjectOfType<GolfBallController>().transform;
      transform.position = new Vector3(GolfBallPosition.position.x, height, GolfBallPosition.position.z);
   }

   // Update is called once per frame
   void Update ( )
   {
      transform.position = new Vector3(GolfBallPosition.position.x, height, GolfBallPosition.position.z);
   }
}
