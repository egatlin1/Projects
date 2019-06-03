using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Amount of damage each bullet will do to its target")]
    public float damage = 5;

    [Tooltip("The speed of the bullet in meters per second")]
    public float speed = 5;

    [Tooltip("How long the bullet will exist in seconds")]
    public float lifeTime = 5;

    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {
        lifeTime -= Time.deltaTime;
        if ( lifeTime < 0 )
            Destroy(gameObject);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
