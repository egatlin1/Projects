using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Tooltip("How much the score is multiplied by once the target is hit. By default, this target is worth the distance it was " +
        "shot from.")]
    public int scoreMultiplier = 1;

    [Tooltip("The speed this target will move at in meters per second")]
    public float speed = 2;

    //[HideInInspector]
    public Transform target;


    private Transform parent;

    // Start is called before the first frame update
    void Start ()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update ()
    {
        parent.position = Vector3.MoveTowards(parent.position, target.position, speed * Time.deltaTime);
    }


    private void OnCollisionEnter ( Collision collision )
    {
        Arrow arrow = collision.gameObject.GetComponent<Arrow>();
        if ( arrow != null )
        {
            int goldenMultiplier = ( arrow.arrowType == Arrow.eArrowType.Golden ) ? 2 : 1;
            Score.Instance.AddScore((int)arrow.distTravelled * scoreMultiplier * goldenMultiplier);

            Destroy(arrow.gameObject);
            Destroy(parent.gameObject);

        }
    }

}
