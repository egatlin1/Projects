using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Rain_Data 
{


    public bool[] Achievements;
    public HighScoreFormat[] highScores = new HighScoreFormat[10];
    public int activeGradientNum;

    public Rain_Data ( Rain_GameManager manager )
    {
        Achievements = manager.achievements;
        highScores = manager.highScores;
        activeGradientNum = manager.activeGradientNum;
    }


}
