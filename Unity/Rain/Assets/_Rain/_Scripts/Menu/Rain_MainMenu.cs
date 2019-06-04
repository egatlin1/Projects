using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_MainMenu : MonoBehaviour
{

    public Rain_HowToPlay howToPlay;

    SceneController scene;
    

    // Start is called before the first frame update
    void Start ( )
    {
        scene = FindObjectOfType<SceneController>();
    }


    // Update is called once per frame
    void Update ( )
    {

    }

    public void HowToPlay ( )
    {
        howToPlay.gameObject.SetActive(true);
        howToPlay.OnActivation();
    }

    public void SceneChange ( string sceneName )
    {
        scene.LoadScene(sceneName);
    }

    public void ExitGame ( )
    {
        Application.Quit();
    }

}
