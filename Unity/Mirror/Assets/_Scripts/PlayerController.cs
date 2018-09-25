using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int s_NumberOfPlayers = 0;

    public float speed = 5f;
    public bool isInvertedX = false;
    public bool isInvertedY = false;


    private Rigidbody2D myRigibody2D;
    private int invertX;
    private int invertY;


	// Use this for initialization
	void Awake ( )
    {
        PlayerController.s_NumberOfPlayers++;
        myRigibody2D = GetComponent<Rigidbody2D>();

        invertX = (isInvertedX) ? -1 : 1;
        invertY = (isInvertedY) ? -1 : 1;
	}
	
	// Update is called once per frame
	void FixedUpdate ( )
    {
        if (EventHandler.s_IsPlaying)
            Move();
	}

    void Move ( )
    {
        float horzontal = Input.GetAxis("Horizontal") * invertX;
        float vertical = Input.GetAxis("Vertical") * invertY;
        Vector2 movement = new Vector2(horzontal, vertical);
        myRigibody2D.AddForce(movement * speed);
    }
}
