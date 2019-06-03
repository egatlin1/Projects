using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2;

    float horiontal;
    float vertical;

    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {
        horiontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    
    private void FixedUpdate ()
    {
        transform.Translate(new Vector3(horiontal, 0, vertical) * speed * Time.deltaTime);
    }
    
}
