using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{

   [SerializeField]
   private Transform target;

   [SerializeField]
   private Vector3 offsetPosition;

   [SerializeField]
   private bool lookAt = true;

   
   public bool canFollow = true;


   private GolfBallController ball;

   private void Awake ( )
   {
      ball = FindObjectOfType<GolfBallController>();

      ball.canTurn = canFollow;
   }


   private void Update ( )
   {
      Refresh();



      if (Input.GetKeyDown(KeyCode.LeftShift) && canFollow)
      {
         canFollow = false;
         ball.canTurn = false;
      }

   }

   public void Refresh ( )
   {
      if (canFollow)
      {
         transform.position = target.TransformPoint(offsetPosition);
      }

      // compute rotation
      if (lookAt)
      {
         transform.LookAt(target);
      }
      else
      {
         transform.rotation = target.rotation;
      }
   }
}
