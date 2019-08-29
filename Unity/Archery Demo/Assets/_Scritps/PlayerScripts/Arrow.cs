using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    [Tooltip("The minimum speed the arrow has to be moving to play the impact sound")]
    float impactSpeedForSounds = 25;


    public enum eArrowType { Normal, Silver, Golden};
    public eArrowType arrowType;


    public AudioClip impactSound;

    AudioSource audioSource;

    Rigidbody rigid;

    Collider[] colliders;

    Vector3 startingPos;

    [HideInInspector]
    public float distTravelled; // the distance travelled by this arrow. to be used in other scripts


    float velocity;


    // Start is called before the first frame update
    void Start ( )
    {
        colliders = GetComponents<Collider>();

        AdjustColliders(false);

        rigid = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();

        rigid.isKinematic = true;
    }


    public void Fire ( float force)
    {
        if ( arrowType == eArrowType.Silver )
            force *= 1.5f;

        rigid.isKinematic = false;
        rigid.AddForce(transform.forward * force, ForceMode.VelocityChange);
        rigid.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        startingPos = transform.position;
    }


    private void Update ()
    {
        if ( !rigid.isKinematic )
        {
            velocity = rigid.velocity.magnitude;
            if ( rigid.velocity != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(rigid.velocity);
        }
    }

    private void AdjustColliders ( bool state  )
    {
        foreach ( Collider c in colliders )
        {
            c.enabled = state;
        }
    }

    private void OnCollisionEnter ( Collision collision )
    {

        if ( velocity >= impactSpeedForSounds ) // checks if the arrow was going the minimum velocity when it impacted
            audioSource.PlayOneShot(impactSound);

        rigid.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rigid.isKinematic = true;
        rigid.constraints = RigidbodyConstraints.FreezeAll;
        AdjustColliders(false);

        distTravelled = Vector3.Distance(startingPos, transform.position);
        
    }

}
