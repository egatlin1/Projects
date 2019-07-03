using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde_PlayerMovement : MonoBehaviour
{

    public float speed = 5;

    Rigidbody2D rigid;

    float vertical;
    float horizontal;

    // Start is called before the first frame update
    void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }


    private void FixedUpdate ()
    {
        rigid.AddForce(new Vector3(horizontal, vertical).normalized * Time.deltaTime * speed);
    }
}
