using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rain_HighScores : MonoBehaviour
{
    public TextMeshProUGUI[] highScores = new TextMeshProUGUI[10];
    public HighScoreFormat[] highScoreFormats = new HighScoreFormat[10];



    #region Singleton
    public static Rain_HighScores instance;

    private void Awake ()
    {
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start ( )
    {

        Rain_Data data = Rain_Saving.LoadRain();

        if ( data != null )
        {
            highScoreFormats = data.highScores;
        }
        else
            Init();
    }


    private void Init ()
    {
        Debug.Log("Init()");
        for ( int i = 0; i < highScoreFormats.Length; i++ )
        {
            highScoreFormats[i] = new HighScoreFormat();
        }
    }

    // Update is called once per frame
    void Update ( )
    {

    }

    // horribly inefficient, fix later
    public void SortScores ( )
    {
        HighScoreFormat tmp;

        for ( int p = 0; p <= highScoreFormats.Length - 2; p++ )
        {
            for ( int i = 0; i <= highScoreFormats.Length - 2; i++ )
            {
                if ( highScoreFormats[i].score > highScoreFormats[i + 1].score )
                {
                    tmp = highScoreFormats[i + 1];
                    highScoreFormats[i + 1] = highScoreFormats[i];
                    highScoreFormats[i] = tmp;
                }
            }
        }
    }


    // horribly inefficient, fix later
    public void SortScores ( int newScore )
    {
        HighScoreFormat[] newArr = new HighScoreFormat[11];

        for ( int i = 0; i < highScoreFormats.Length; i++ )
        {
            newArr[i] = highScoreFormats[i];
        }
        newArr[10] = new HighScoreFormat(newScore, "You", System.DateTime.Now.ToString("MM/dd"));

        HighScoreFormat tmp;

        for ( int p = 0; p <= newArr.Length - 2; p++ )
        {
            for ( int i = 0; i <= newArr.Length - 2; i++ )
            {
                if ( newArr[i].score < newArr[i + 1].score )
                {
                    tmp = newArr[i + 1];
                    newArr[i + 1] = newArr[i];
                    newArr[i] = tmp;
                }
            }
        }

        for ( int i = 0; i < highScoreFormats.Length; i++ )
        {
            highScoreFormats[i] = newArr[i];
            
        }

        Save();
    }


    public void AddNewScore ( int newScore )
    {
        SortScores(newScore);
    }

    public void DisplayScores ( )
    {
        for ( int i = 0; i < highScoreFormats.Length; i++ )
        {
            highScores[i].text = highScoreFormats[i].ToString();
        }
    }

    public void Save ( )
    {
        FindObjectOfType<Rain_GameManager>().SetHighScores(highScoreFormats);
    }



}
