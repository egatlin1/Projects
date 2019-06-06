using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombFullAuto : Rain_Bomb
{


    public override void OnDeath ()
    {
        Rain_Player.instance.StartFullAutoShot();
        Destroy(gameObject);
    }


}
