using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombRapid : Rain_Bomb
{

    public override void OnDeath ()
    {
        Rain_Player.instance.StartRapidShot();
        Destroy(gameObject);
    }


}
