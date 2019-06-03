using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombHealth : Rain_Bomb
{




    public override void OnDeath ()
    {
        Rain_Lives.instance.AddLife();
        Destroy(gameObject);
    }

}
