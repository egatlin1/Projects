using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Achievements : MonoBehaviour
{
    public Rain_GameManager manager;

    public Gradient[] gradients;
    public int activeGradientNum = 0;

    public bool[] achievements;

    // Start is called before the first frame update
    void Start ()
    {
        Rain_Data data = Rain_Saving.LoadRain();

        if ( data != null )
        {
            activeGradientNum = data.activeGradientNum;
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
        
    }

    public bool[] GetAchievements ( )
    {
        return achievements;
    }
}
