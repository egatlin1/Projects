using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallController : MonoBehaviour
{

   public float rotationSpeed = 30f;
   public bool canTurn = true;
   public bool canReset = true;

   public GameObject UI;
   public Rigidbody m_rigidbody;

   private bool hasBeenHit = false;
   public Vector3 startingPos;
   
   private LineRenderer directionLine;
   private CameraLookAt m_camera;
   private Launcher launcher;
   private Transform flag;

   private void Awake ( )
   {
      directionLine = GetComponent<LineRenderer>();
      m_camera = FindObjectOfType<CameraLookAt>();
      m_rigidbody = GetComponent<Rigidbody>();
      launcher = GetComponent<Launcher>();
      flag = GameObject.FindGameObjectWithTag("Flag").transform;

      startingPos = transform.position;


      ResetBall();

   }

   public void RestBallToLastPos ( )
   {
      transform.position = startingPos;
      ResetBall();
   }

   private void ResetBall ( )
   {
      m_rigidbody.constraints = RigidbodyConstraints.FreezeAll;

      // makes the ball always look at the flag when it resets
      transform.LookAt(flag);
      Quaternion rotation = transform.rotation;
      rotation.x = 0.00000f;
      rotation.z = 0.00000f;
      transform.rotation = rotation;


      directionLine.enabled = true;
      canTurn = true;
      hasBeenHit = false;
      m_camera.ResetCamera();
      startingPos = transform.position;
      UI.SetActive(true);
   }


   private void Update ( )
   {

      if (Input.GetKeyDown(KeyCode.Space) )
      {
         LaunchBall();
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

      if (m_rigidbody.velocity == Vector3.zero && hasBeenHit && startingPos != transform.position && canReset)
      {
         ResetBall();
      }
   }


   public void LaunchBall ( )
   {
      if (!canTurn && m_rigidbody.velocity == Vector3.zero)
      {
         m_rigidbody.constraints = RigidbodyConstraints.None;
         launcher.LaunchGolfBall();
         directionLine.enabled = false;
         hasBeenHit = true;
         UI.SetActive(false);
      }
   }

}
