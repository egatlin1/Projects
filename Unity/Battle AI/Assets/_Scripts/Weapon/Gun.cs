using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Tooltip("Reference to the bullet prefab used to instantiate new bullets")]
    public Bullet bullet;

    public GameObject bulletSpawnPoint;

    [Tooltip("Amount of time in seconds between bullets")]
    public float rateOfFire = 0.25f;

    [Tooltip("When true the gun will fire at the rate of fire choesn above")]
    public bool isFiring = false;


    // Start is called before the first frame update
    void Start ( )
    {
        StartCoroutine(Shoot());
    }


    IEnumerator Shoot ( )
    {
        WaitForSeconds timer = new WaitForSeconds(rateOfFire);
        while ( true )
        {
            if ( !isFiring )
            {
                yield return null;
                continue;
            }

            Instantiate(bullet, bulletSpawnPoint.transform.transform.position, bulletSpawnPoint.transform.rotation);
            yield return timer;
        }
    }
    

}
