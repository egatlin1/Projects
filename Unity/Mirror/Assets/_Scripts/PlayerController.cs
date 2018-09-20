using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool isInvertedX = false;
    public bool isInvertedY = false;


    private Rigidbody2D myRigibody2D;
    private int invertX;
    private int invertY;


	// Use this for initialization
	void Awake ( )
    {
        myRigibody2D = GetComponent<Rigidbody2D>();

        invertX = (isInvertedX) ? -1 : 1;
        invertY = (isInvertedY) ? -1 : 1;
	}
	
	// Update is called once per frame
	void Update ( )
    {
        float horzontal = Input.GetAxis("Horizontal") * invertX;
        float vertical = Input.GetAxis("Vertical") * invertY;

        Move(horzontal, vertical);
	}

    void Move ( float h, float v)
    {
        Vector2 movement = new Vector2(h, v);
        myRigibody2D.AddForce(movement * speed); // * Time.deltaTime);
    }
}
