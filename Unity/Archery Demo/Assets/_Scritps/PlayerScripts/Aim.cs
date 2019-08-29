using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{

    public GameObject cam;

    public float distToStopAdjustingAim = 5;
    public bool showDebugGizmos = true;

    // Start is called before the first frame update
    void Start ( )
    {

    }

    /// <summary>
    /// Draws a ray to show where the bow is aiming for debug purposes
    /// </summary>
    private void OnDrawGizmos ()
    {
        if ( showDebugGizmos && cam != null)
        {
            RaycastHit raycast;

            if ( Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out raycast, 100) )
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(cam.transform.position, raycast.point);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, raycast.point);
            }
            else
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 100);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * 100);
            }
        }

    }


    // Update is called once per frame
    void Update ( )
    {
        RaycastHit raycast;

        if ( Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out raycast, 100) )
        {
            if ( Vector3.Distance(cam.transform.position, raycast.point) > distToStopAdjustingAim )
                transform.LookAt(raycast.point);
        }
        else
            transform.LookAt(cam.transform.position + cam.transform.TransformDirection(Vector3.forward) * 100);
    }
}
