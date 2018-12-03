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
    private bool isMaxHits = false;
    public Vector3 startingPos;

    private float slowBallTime = 2f;
    private float slowBallCountDown = 2f;

    private LineRenderer directionLine;
    private CameraLookAt m_camera;
    private Launcher launcher;
    private Transform flag;
    private HitCounter counter;

    private void Awake()
    {
        directionLine = GetComponent<LineRenderer>();
        m_camera = FindObjectOfType<CameraLookAt>();
        m_rigidbody = GetComponent<Rigidbody>();
        launcher = GetComponent<Launcher>();
        flag = GameObject.FindGameObjectWithTag("Flag").transform;
        counter = FindObjectOfType<HitCounter>();


        startingPos = transform.position;


        ResetBall();

    }

    public void RestBallToLastPos()
    {
        transform.position = startingPos;
        ResetBall();
    }

    private void ResetBall()
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



    void FixedUpdate()
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

        if (!isMaxHits)
        {
            transform.Rotate(v * rotationSpeed * Time.deltaTime, h * rotationSpeed * Time.deltaTime, 0);


            // clamps rotation so that you can't rotate backwards
            // clamps X rotation of the ball between 0 and -60 degrees ( -60 degrees is an upwards angle)
            Quaternion rotation = transform.rotation;
            Vector3 angle = rotation.eulerAngles;
            angle.x = (angle.x > 180) ? angle.x - 360 : angle.x;
            angle.x = Mathf.Clamp(angle.x, -60, 0);
            Debug.Log(angle);
            transform.rotation = Quaternion.Euler(angle);
        }


        if (m_rigidbody.velocity.magnitude < .5f && hasBeenHit && startingPos != transform.position && canReset)
        {
            if (slowBallCountDown <= 0)
            {
                ResetBall();
                isMaxHits = counter.MaxHits();
                slowBallCountDown = slowBallTime;
            }
            else
                slowBallCountDown -= Time.deltaTime;
        }
    }


    public void LaunchBall()
    {
        if (!canTurn && m_rigidbody.velocity == Vector3.zero && !isMaxHits)
        {
            counter.AddHit();
            m_rigidbody.constraints = RigidbodyConstraints.None;
            launcher.LaunchGolfBall();
            directionLine.enabled = false;
            hasBeenHit = true;
            UI.SetActive(false);
        }
    }

}
