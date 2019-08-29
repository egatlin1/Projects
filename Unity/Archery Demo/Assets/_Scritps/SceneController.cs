using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private string cashedSceneName;



    #region Singleton

    private static SceneController _Instance;
    public static SceneController Instance
    {
        private set
        {
            if ( _Instance != null )
                Debug.LogWarning("SceneController::Instance.set ~ setting value of _Instance again, possible bug");
            _Instance = value;
        }
        get
        {
            return _Instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start ()
    {
        int numOfControllers = FindObjectsOfType<SceneController>().Length;
        if ( numOfControllers > 1 ) // makes sure there is only one SceneController is in the scene at a time
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }


    public void LoadScene ( string sceneName )
    {
        cashedSceneName = sceneName;
        if ( FindObjectOfType<SceneChangeEffect>() )
            FindObjectOfType<SceneChangeEffect>().PlayEffect(LoadSceneAfterEffect);
        else
            LoadSceneAfterEffect();
    }


    private void LoadSceneAfterEffect ( )
    {
        if ( cashedSceneName == "Exit" )
        {
            Application.Quit();
            return;
        }
        SceneManager.LoadScene(cashedSceneName);
    }

}
