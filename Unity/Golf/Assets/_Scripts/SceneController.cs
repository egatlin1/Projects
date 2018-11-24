using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

   public GameObject loadingScreen;
   public Slider loadingBar;

   bool oneShot = false;


   // Use this for initialization
   void Awake ( )
   {
      int numOfMusicControllers = FindObjectsOfType<SceneController>().Length;

      if (numOfMusicControllers > 1)
         Destroy(gameObject);
      else
         DontDestroyOnLoad(this.gameObject);

   }

   public void LoadLevel ( string levelName)
   {
      if (!oneShot)
         StartCoroutine(LoadAsynchronously(levelName));
      else
      {
         StartCoroutine(LoadAsynchronously("Menu"));
         oneShot = false;
      }
   }

   public void LoadLevelOneShot ( string levelName )
   {
      LoadLevel(levelName);

      oneShot = true;
   }

   public void ReloadCurrentLevel ( )
   {
      StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().name));
   }

   public void ExitGame ( )
   {
      Application.Quit();
   }

   IEnumerator LoadAsynchronously ( string levelName )
   {
      AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

      loadingScreen.SetActive(true);

      while (!operation.isDone)
      {
         float progress = Mathf.Clamp01(operation.progress / .9f);

         loadingBar.value = progress;

         yield return null;
      }
      loadingScreen.SetActive(false); //TODO: test to see if this works
   }
}
