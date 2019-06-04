using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombBig : Rain_Bomb
{


    public override void OnDeath ()
    {

        Debug.Log(name + "   " + transform.localScale);

        if ( transform.localScale.x > 1)
        {
            transform.localScale = new Vector3(transform.localScale.x - 1, transform.localScale.y -1, 1);
        }
        else
        {
            Rain_ScoreKeeper.instance.AddScore(5);
            Destroy(gameObject);
        }
    }


}
