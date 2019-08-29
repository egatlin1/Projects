using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    private Camera cam;

    private Rigidbody rb;
    private Collider col;

    //input.GetAxis() data. Made vars for ease of reading.
    private float horizontal;
    private float vertical;
    private float mouseMovementX;
    public float mouseMovementY;

    //filled in by collider bounds.
    private float distToGround;

    [Tooltip("Speed to sprint in both x and y directions.")]
    [SerializeField]
    private float sprintSpeedMultiplier = 2;

    [Tooltip("Movement speed in both x and y directions.")]
    [SerializeField]
    private float moveSpeed = 5;

    [Tooltip("horizontal speed of the player camera.")]
    [SerializeField]
    private float horizontalRotationSpeed = 100;

    [Tooltip("vertical speed of the player camera.")]
    [SerializeField]
    private float verticalRotationSpeed = 200;

    [Tooltip("the min angle the player can look down.")]
    [SerializeField]
    private float yMinLookAngle = -50;

    [Tooltip("the max angle the player can look up")]
    [SerializeField]
    private float yMaxLookAngle = 50;

    [Tooltip("set to true to let the player jump")]
    [SerializeField]
    bool canJump = true;

    [Tooltip("used to add relative jump force to player")]
    [SerializeField]
    private float jumpForce = 300;

    private float yRot = 0.0f;


    // Use this for initialization
    void Start ()
    {
        cam = Camera.main;

        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        distToGround = col.bounds.extents.y;

        Cursor.lockState =  CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update ()
    {
        GetInput();

        //gets key input for movement times the movespeed for both x and y.
        transform.Translate(horizontal * Time.deltaTime * moveSpeed, 0, vertical * Time.deltaTime * moveSpeed);

        //uses mouse X data to rotate player.
        transform.Rotate(0, mouseMovementX * Time.deltaTime * horizontalRotationSpeed, 0);

        //uses mouse Y data to rotate the camera
        RotateCameraY();

    }

    //gets the input for x and y movement. Also gets the mouse X for camera left and right.
    //checks for sprint key and jump key. 
    private void GetInput ()
    {

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mouseMovementX = Input.GetAxis("Mouse X");
        mouseMovementY = Input.GetAxis("Mouse Y");

        //adds relative y rigidbody force to player if grounded and player presses jump key. based on jumpforce var.
        if ( Jump() )
        {
            rb.AddRelativeForce(0, jumpForce, 0);
        }

        //if player is pressing sprint key multiplies by sprintspeed in both axises. 
        if ( Sprinting() )
        {
            horizontal *= sprintSpeedMultiplier;
            vertical *= sprintSpeedMultiplier;
        }
        else
        {
            horizontal *= 2;
            vertical *= 1;
        }

    }

    //returns true raycast hits ground below player.
    private bool IsGrounded ()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f) && canJump;
    }

    //returns true if player is pressing shift.
    private bool Sprinting ()
    {
        if ( Input.GetKey(KeyCode.LeftShift) )
        {
            return true;
        }
        else
            return false;
    }

    //returns true if player is pressing space and is grounded.
    private bool Jump ()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && IsGrounded() )
        {
            return true;
        }
        else
            return false;
    }

    //handles locking the Y camera rotation based on given min and max angles.
    private void RotateCameraY ()
    {
        yRot += mouseMovementY * verticalRotationSpeed * Time.deltaTime;

        yRot = Mathf.Clamp(yRot, yMinLookAngle, yMaxLookAngle);

        cam.transform.localEulerAngles = new Vector3(-yRot, 0, 0);
    }

}
