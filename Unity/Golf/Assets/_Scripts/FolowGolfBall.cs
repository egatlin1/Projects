using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowGolfBall : MonoBehaviour
{
   GolfBallController GolfBallPosition;
   public float height;

   public GameObject arrowIcon;


   // Use this for initialization
   void Awake ( )
   {
      GolfBallPosition = FindObjectOfType<GolfBallController>();
      transform.position = new Vector3(GolfBallPosition.transform.position.x, height, GolfBallPosition.transform.position.z);
   }

   // Update is called once per frame
   void Update ( )
   {
      transform.position = new Vector3(GolfBallPosition.transform.position.x, height, GolfBallPosition.transform.position.z);

      if ( GolfBallPosition.m_rigidbody.velocity == Vector3.zero )
      {
         arrowIcon.SetActive(true);
         Vector3 ball = GolfBallPosition.transform.rotation.eulerAngles;
         Vector3 arrow = transform.rotation.eulerAngles;

         arrow = new Vector3(arrow.x, ball.y, arrow.z);

         transform.rotation = Quaternion.Euler(arrow);
      }
      else
      {
         arrowIcon.SetActive(false);
      }

   }
}
