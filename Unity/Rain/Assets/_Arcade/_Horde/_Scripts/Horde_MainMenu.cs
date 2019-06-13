using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde_MainMenu : MonoBehaviour
{

    private SceneController scene;

    // Start is called before the first frame update
    void Start ()
    {
        scene = FindObjectOfType<SceneController>();
    }



    public void LoadScene ( string sceneToLoad )
    {
        scene.LoadScene(sceneToLoad);
    }




    public void Exit ()
    {
        // TODO: delete any minigame related singleton objects, possibly save
        scene.LoadScene("Arcade");
    }


    // Update is called once per frame
    void Update ()
    {

    }
}
