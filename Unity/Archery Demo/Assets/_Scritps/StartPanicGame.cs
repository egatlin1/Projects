using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartPanicGame : MonoBehaviour
{
    [Tooltip("Title to appear above the floating cube")]
    public string title;

    [Tooltip("The difficulty of the game. lower the number the easier the game")]
    [Range(0,2)]
    public int difficulty;

    PanicManager panic;

    private void Awake ()
    {
        panic = FindObjectOfType<PanicManager>();

        GetComponentInChildren<TextMeshProUGUI>().text = title;

        // since the canvas has a forward direciton of facing away from the camera, I am reversing the text so that it can be readable from
        // the cameras point of view
        GetComponentInChildren<TextMeshProUGUI>().gameObject.transform.Rotate(0, 180, 0);
    }


    private void OnCollisionEnter ( Collision collision )
    {
        if ( collision.gameObject.GetComponent<Arrow>() )
        {
            Destroy(collision.gameObject);
            panic.StartGame(difficulty);
        }
    }

}
