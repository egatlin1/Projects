﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

   public GameObject loadingScreen;
   public Slider loadingBar;

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
      StartCoroutine(LoadAsynchronously(levelName));

      loadingScreen.SetActive(false); //TODO: test to see if this works
   }

   IEnumerator LoadAsynchronously ( string levelName )
   {
      AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

      loadingScreen.SetActive(true);

      while (!operation.isDone)
      {
         float progress = Mathf.Clamp01(operation.progress / .9f);

         loadingBar.value = progress;
         Debug.Log(progress);

         yield return null;
      }

   }
}
