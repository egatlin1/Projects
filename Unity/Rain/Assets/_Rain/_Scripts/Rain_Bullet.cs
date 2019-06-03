using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Bullet : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody2D rigid;

    private bool hasBounced = false;

    // Start is called before the first frame update
    void Start ()
    {

    }

    public void SetHeading ( Vector3 newUp, Color color )
    {
        transform.up = newUp;
        GetComponent<SpriteRenderer>().color = color;
        rigid.AddForce(transform.up * speed);
    }


    // Update is called once per frame
    void Update ()
    {

    }

    public void HitWall ()
    {
        if ( !hasBounced )
        {
            hasBounced = true;
            rigid.velocity = new Vector2(rigid.velocity.x * -1, rigid.velocity.y);
        }
    }

}
