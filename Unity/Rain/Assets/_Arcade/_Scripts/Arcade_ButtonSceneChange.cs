using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade_ButtonSceneChange : MonoBehaviour
{
    public string message;
    public string tagTrigger = "Player";
    public string sceneToLoad;

    private bool isPlayerInRange = false;

    private SceneController controller;

    // Start is called before the first frame update
    void Start ()
    {
        controller = FindObjectOfType<SceneController>();
    }

    // Update is called once per frame
    void Update ()
    {
        if ( Input.GetKeyDown(KeyCode.E) && isPlayerInRange )
        {
            controller.LoadScene(sceneToLoad);
        }
    }



    private void OnTriggerEnter2D ( Collider2D other )
    {
        if ( other.tag == tagTrigger )
        {
            isPlayerInRange = true;
            //Arcade_HelperText.instance.DisplayTest(message);
        }
    }

    private void OnTriggerExit2D ( Collider2D other )
    {
        if ( other.tag == tagTrigger )
        {
            isPlayerInRange = false;
            //Arcade_HelperText.instance.DisableText();
        }
    }
}
