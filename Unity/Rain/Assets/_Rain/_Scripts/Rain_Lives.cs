using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rain_Lives : MonoBehaviour
{

    #region Singleton

    public static Rain_Lives instance;

    private void Awake ()
    {
        instance = this;
    }

    #endregion
    

    public int lives = 3;


    public TextMeshProUGUI text;
    public TextMeshProUGUI finalText;
    public GameObject levelUI;
    public GameObject creditUI;
    public ParticleSystem Fireworks;

    // Start is called before the first frame update
    void Start ( )
    {

    }

    // Update is called once per frame
    void Update ( )
    {

    }


    public void AddLife ( )
    {
        lives++;
        text.text = "Lives:  " + lives;
    }


    public void LoseLife ( )
    {
        lives--;
        if ( lives < 0 )
            lives = 0;
        text.text = "LIves:  " + lives;

        if ( lives == 0 )
            StartCoroutine(GameOver());

    }


    public void ResetWithLives ( int newLives )
    {
        lives = newLives;
        text.text = "LIves:  " + lives;
    }


    public bool IsGameOver ( )
    {
        return lives <= 0;
    }

    IEnumerator GameOver ( )
    {
        yield return new WaitForSeconds(2);
        levelUI.SetActive(false);
        yield return new WaitForSeconds(2);

        
        Fireworks.Play();
        while ( Camera.main.transform.position.y > -10 )
        {
            Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, new Vector3(0, -10, -10), Time.deltaTime);
            if ( Vector3.Distance(Camera.main.transform.position, new Vector3(0, -10, -10)) < .1f )
                Camera.main.transform.position = new Vector3(0, -10, -10);
            yield return null;
        }


        creditUI.SetActive(true);

        finalText.text = "Final Score: " + Rain_ScoreKeeper.instance.GetScore();
        yield return null;
    }
}
