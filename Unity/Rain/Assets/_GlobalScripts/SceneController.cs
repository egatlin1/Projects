using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public string playerName = "Player";

    #region Singleton
    private void Awake ()
    {
        int objs = FindObjectsOfType<SceneController>().Length;
        if ( objs > 1 )
            Destroy(gameObject); //makes sure there is only one SceneController in the scene(the oldest SceneController)

        DontDestroyOnLoad(this);
    }

    #endregion

    // Start is called before the first frame update
    void Start ( )
    {

    }


    public void LoadScene ( string sceneToLoad )
    {
        SceneManager.LoadScene(sceneToLoad);
    }


    // Update is called once per frame
    void Update ( )
    {

    }
}
