using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTwo : MonoBehaviour
{
    public float speed = 2;
    public float rotationSpeed = 45;

    public float jumpForce = 350;
    

    float horiontal;
    float vertical;

    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        horiontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            myRigidbody.AddForce(Vector3.up * jumpForce);
        }


    }

    private void FixedUpdate ()
    {
        transform.Translate(new Vector3(0, 0, vertical) * speed * Time.deltaTime);
        transform.Rotate(0, horiontal * rotationSpeed * Time.deltaTime, 0);
    }
}
