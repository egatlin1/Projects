using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombBlanket : Rain_Bomb
{


    public override void OnDeath ()
    {
        Rain_Player.instance.StartBlanketShot();
        Destroy(gameObject);
    }

}
