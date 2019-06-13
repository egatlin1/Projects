using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade_Player : MonoBehaviour
{
    public float moveSpeed = 5;


    private float horizontal;
    private float vertical;

    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //if ( !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) &&
        //     !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) )
        //{
        //    vertical /= 1.1f;
        //    rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y / 1.1f);
        //}

        //if ( !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) &&
        //     !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) )
        //{
        //    horizontal /= 1.1f;
        //    rigid.velocity = new Vector2(rigid.velocity.x / 1.1f, rigid.velocity.y);
        //}
    }



    private void FixedUpdate ()
    {
        
        rigid.AddForce(new Vector2(horizontal, vertical ).normalized * moveSpeed * Time.deltaTime);
    }
}
