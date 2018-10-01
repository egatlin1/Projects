using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
   private void Awake ( )
   {
      Time.timeScale = 1f;
   }

   public void loadScene ( string sceneName )
    {
        SceneManager.LoadScene(sceneName);
    }


    public void reloadCurrentScene ( )
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
