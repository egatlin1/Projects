using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombSnipper : Rain_Bomb
{

    public override void OnDeath ()
    {
        Rain_Player.instance.StartSnipperShot();
        Destroy(gameObject);
    }

}
