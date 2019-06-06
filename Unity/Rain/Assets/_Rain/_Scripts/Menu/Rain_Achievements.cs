﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rain_Achievements : MonoBehaviour
{
    public int activeGradientNum = 0;

    public bool[] achievements;



    public Rain_GameManager manager;

    public Gradient[] gradients;
    public GameObject[] blockOuts;

    public TextMeshProUGUI[] titles;


    private Color selectedColor = Color.yellow;

    // Start is called before the first frame update
    void Start ()
    {
        achievements = new bool[gradients.Length];
        manager = FindObjectOfType<Rain_GameManager>();

        Rain_Data data = Rain_Saving.LoadRain();

        if ( data != null )
        {

            for ( int i = 0; i < data.achievements.Length; i++ ) // load in values for unlocked achiements
            {
                achievements[i] = data.achievements[i];
            }
            activeGradientNum = data.activeGradientNum;

            manager.SetGradientWithoutSaving(gradients[activeGradientNum], activeGradientNum); // set up last active achievement

        }
        titles[activeGradientNum].color = selectedColor; // set active gradient title to yellow to show which is selected
        achievements[0] = true; // Default always active
        manager.SetAchievements(achievements);

        for ( int i = 0; i < achievements.Length; i++ ) // block out selecting gradients until achievements are unlocked
        {
            blockOuts[i].SetActive(!achievements[i]);
        }
    }

    // Update is called once per frame
    void Update ( )
    {

    }

    public Gradient GetActiveGradient ( )
    {
        return gradients[activeGradientNum];
    }

    public int GetActiveGradientNum ( )
    {
        return activeGradientNum;
    }

    public void SetActiveGradientNum ( int newNum)
    {
        activeGradientNum = newNum;
        manager.SetGradient(gradients[newNum], newNum);
        ResetTitleColors();
        titles[activeGradientNum].color = selectedColor;
        
    }

    private void ResetTitleColors ( )
    {
        for ( int i = 0; i < titles.Length; i++ )
        {
            titles[i].color = Color.white;
        }
    }


    public bool[] GetAchievements ( )
    {
        return achievements;
    }
}
