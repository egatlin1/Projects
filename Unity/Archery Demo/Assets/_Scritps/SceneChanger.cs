using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    [Tooltip("The name of the scene to be loaded. If the scene name is set to Exit, the game will quit")]
    public string sceneToLoad;

    private void Awake ()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = sceneToLoad;

        // since the canvas has a forward direciton of facing away from the camera, I am reversing the text so that it can be readable from
        // the cameras point of view
        GetComponentInChildren<TextMeshProUGUI>().gameObject.transform.Rotate(0, 180, 0); 
    }

    private void OnCollisionEnter ( Collision collision )
    {
        if ( collision.gameObject.GetComponent<Arrow>() )
        {
            SceneController.Instance.LoadScene(sceneToLoad);
        }
    }

}
