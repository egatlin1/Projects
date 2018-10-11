using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
   public float rotationSpeed = 30f;
   public float moveSpeed = 2000f;
   public bool canTurn = true;

   private bool hasBeenHit = false;
   private Vector3 startingPos;

   private ConstantForce force;
   private LineRenderer directionLine;
   private CameraLookAt m_camera;
   private Rigidbody m_rigidbody;

   private void Awake ( )
   {
      force = GetComponent<ConstantForce>();
      directionLine = GetComponent<LineRenderer>();
      m_camera = FindObjectOfType<CameraLookAt>();
      m_rigidbody = GetComponent<Rigidbody>();

      startingPos = transform.position;

      force.relativeForce = new Vector3(0f, 0f, moveSpeed);
      force.enabled = false;

      m_rigidbody.constraints = RigidbodyConstraints.FreezePosition;

   }

   private void ResetBall ( )
   {
      transform.rotation = Quaternion.Euler( Vector3.zero);
      directionLine.enabled = true;
      canTurn = true;
      hasBeenHit = false;
      m_camera.canFollow = true;
      startingPos = transform.position;
   }


   private void Update ( )
   {

      if ( Input.GetKeyDown(KeyCode.Space) && !canTurn)
      {
         m_rigidbody.constraints = RigidbodyConstraints.None;
         force.enabled = true;
         directionLine.enabled = false;
         hasBeenHit = true;
      }

      //Debug.Log(rigidbody.velocity);

   }

   void FixedUpdate ( )
   {

      float h = Input.GetAxis("Horizontal");
      float v = Input.GetAxis("Vertical");

      if ( canTurn && m_rigidbody.velocity == Vector3.zero)
      {
         v = 0f;
      }
      else if (!canTurn && m_rigidbody.velocity == Vector3.zero)
      {
         h = 0f;
      }

      transform.Rotate(v * rotationSpeed * Time.deltaTime, h * rotationSpeed * Time.deltaTime, 0);

      force.enabled = false;

      if (m_rigidbody.velocity == Vector3.zero && hasBeenHit && startingPos != transform.position)
      {
         Debug.Log("Here");
         ResetBall();
      }
   }
}
