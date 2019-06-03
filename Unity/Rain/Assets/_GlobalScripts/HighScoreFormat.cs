using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//string day = System.DateTime.Now.ToString("MM/dd");
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


[System.Serializable]
public class HighScoreFormat
{
    public int score;
    public string name;
    public string date;

    public HighScoreFormat ( int newScore, string newName, string newDate )
    {
        score = newScore;
        name = newName;
        date = newDate;
    }


}
