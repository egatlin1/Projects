using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    public void loadScene ( string sceneName )
    {
        SceneManager.LoadScene(sceneName);
    }


    public void reloadCurrentScene ( )
    {
        Debug.Log("" + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
