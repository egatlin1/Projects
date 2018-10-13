using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallController : MonoBehaviour
{

   public float rotationSpeed = 30f;
   public bool canTurn = true;

   private bool hasBeenHit = false;
   private Vector3 startingPos;
   
   private LineRenderer directionLine;
   private CameraLookAt m_camera;
   private Rigidbody m_rigidbody;
   private Launcher launcher;

   private void Awake ( )
   {
      directionLine = GetComponent<LineRenderer>();
      m_camera = FindObjectOfType<CameraLookAt>();
      m_rigidbody = GetComponent<Rigidbody>();
      launcher = GetComponent<Launcher>();


      startingPos = transform.position;


      m_rigidbody.constraints = RigidbodyConstraints.FreezeAll;

   }

   private void ResetBall ( )
   {

      m_rigidbody.constraints = RigidbodyConstraints.FreezeAll;
      transform.rotation = Quaternion.Euler(Vector3.zero);
      directionLine.enabled = true;
      canTurn = true;
      hasBeenHit = false;
      m_camera.ResetCamera();
      startingPos = transform.position;
   }


   private void Update ( )
   {

      if (Input.GetKeyDown(KeyCode.Space) && !canTurn)
      {
         m_rigidbody.constraints = RigidbodyConstraints.None;
         launcher.LaunchGolfBall();
         directionLine.enabled = false;
         hasBeenHit = true;
      }
      

   }

   void FixedUpdate ( )
   {

      float h = Input.GetAxis("Horizontal");
      float v = Input.GetAxis("Vertical");

      if (canTurn && m_rigidbody.velocity == Vector3.zero)
      {
         v = 0f;
      }
      if (!canTurn && m_rigidbody.velocity == Vector3.zero)
      {
         h = 0f;
      }

      transform.Rotate(v * rotationSpeed * Time.deltaTime, h * rotationSpeed * Time.deltaTime, 0);

      if (m_rigidbody.velocity == Vector3.zero && hasBeenHit && startingPos != transform.position)
      {
         ResetBall();
      }
   }
}
