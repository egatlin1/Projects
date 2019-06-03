using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombIncinerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {

    }


    private void OnTriggerEnter2D ( Collider2D collision )
    {

        Rain_Bomb bomb = collision.GetComponent<Rain_Bomb>();

        if ( bomb )
        {
            if ( bomb.doesLoseLifeOnDeath && !Rain_Lives.instance.IsGameOver() )
                Rain_Lives.instance.LoseLife();
            Destroy(collision.gameObject);
        }
    }
}
