using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Walls : MonoBehaviour
{


    private void OnTriggerEnter2D ( Collider2D collision )
    {
        if ( collision.tag == "Bullet" )
        {
            collision.GetComponent<Rain_Bullet>().HitWall();
        }
    }

}
