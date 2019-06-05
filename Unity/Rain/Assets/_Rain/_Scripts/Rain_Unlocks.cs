using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Unlocks : MonoBehaviour
{

    public bool[] achievements;


    public Rain_GameManager manager;
    public GameObject[] achievementTextBlockOut; // should be one shorter than total number of gradients

    // Start is called before the first frame update
    void Start ( )
    {

        manager = FindObjectOfType<Rain_GameManager>();

        Rain_Data data = Rain_Saving.LoadRain();

        if ( data != null )
        {
            achievements = data.achievements;

            for ( int i = 0; i < achievementTextBlockOut.Length; i++ )
            {
                achievementTextBlockOut[i].SetActive(!achievements[i + 1]); // plus one because default color is already unlocked
            }
        }
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( !achievements[1] )
            CheckFirstAchievement();
        if ( !achievements[2] )
            CheckSecondAchievement();

    }


    private void CheckFirstAchievement ( )
    {
        if ( Rain_ScoreKeeper.instance.GetScore() >= 100 )
        {
            achievements[1] = true;
            achievementTextBlockOut[0].SetActive(false);
        }
        manager.SetAchievements(achievements);
    }



    private void CheckSecondAchievement ()
    {
        if ( !Rain_Lives.instance.HasLosAtLife() && Rain_ScoreKeeper.instance.GetScore() >= 150 )
        {
            achievements[2] = true;
            achievementTextBlockOut[1].SetActive(false);
        }
        manager.SetAchievements(achievements);
    }

}
