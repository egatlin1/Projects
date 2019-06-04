using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_MainMenu : MonoBehaviour
{

    SceneController scene;

    // Start is called before the first frame update
    void Start ( )
    {
        scene = FindObjectOfType<SceneController>();
    }

    public void SceneChange ( string sceneName )
    {
        scene.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update ( )
    {

    }
}
