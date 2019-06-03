using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;

    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {

    }

    public void TakeDamage ( float damage )
    {
        if ( health - damage < 0 )
            health = 0;
        else
         health -= damage;
    }

    public float GetHealth ( )
    {
        return health;
    }



    private void OnTriggerEnter ( Collider other )
    {
        Bullet bullet = other.GetComponent<Bullet>();
        if ( bullet )
        {
            TakeDamage(bullet.damage);
            Destroy(bullet.gameObject);
            if ( GetHealth() == 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

}
