using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Tooltip("Value applied when this target is hit by an arrow")]
    public int value = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnCollisionEnter ( Collision collision )
    {
        if ( collision.gameObject.GetComponent<Arrow>() != null )
        {
            Score.Instance.AddScore(value);
        }
    }

}
