using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowGolfBall : MonoBehaviour
{
   Transform GolfBallPosition;
   // Use this for initialization
   void Awake ( )
   {
      GolfBallPosition = FindObjectOfType<GolfBallController>().transform;
      transform.position = new Vector3(GolfBallPosition.position.x, 100f,GolfBallPosition.position.z);
   }

   // Update is called once per frame
   void Update ( )
   {
      transform.position = new Vector3(GolfBallPosition.position.x, 100f, GolfBallPosition.position.z);
   }
}
