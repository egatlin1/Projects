using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;
    public float lifeTime = 3;

    // Update is called once per frame
    void Update ( )
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


        lifeTime -= Time.deltaTime;
        if ( lifeTime < 0 )
            Destroy(gameObject);

    }
}
