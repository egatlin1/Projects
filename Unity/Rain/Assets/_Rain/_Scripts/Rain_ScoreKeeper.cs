using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rain_ScoreKeeper : MonoBehaviour
{
    #region Singleton

    public static Rain_ScoreKeeper instance;

    private void Awake ()
    {
        instance = this;
    }

    #endregion


    public TextMeshProUGUI text;
    int score = 0;

    // Start is called before the first frame update
    void Start ( )
    {   

    }

    // Update is called once per frame
    void Update ( )
    {

    }   

    public void AddScore ( )
    {
        score++;
        text.text = "Score: " + score;
    }

    public int GetScore ( )
    {
        return score;
    }

    public void ResetScore ( )
    {
        score = 0;
        text.text = "Score: " + score;
    }

}
