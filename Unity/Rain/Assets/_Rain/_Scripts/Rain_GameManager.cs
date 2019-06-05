using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_GameManager : MonoBehaviour
{

    //public Gradient[] gradients;
    public Rain_Achievements rainAch;
    
    public Gradient activeGradient;

    public HighScoreFormat[] highScores = new HighScoreFormat[10];
    public bool[] achievements;
    public int activeGradientNum = 0;

    private void Awake ()
    {
        int num = FindObjectsOfType<Rain_GameManager>().Length;

        if ( num > 1 )
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this);
    }


    // Start is called before the first frame update
    void Start ( )
    {
        Rain_Data data = Rain_Saving.LoadRain();

        if ( data != null )
        {
            highScores = data.highScores;
            achievements = data.Achievements;
            activeGradientNum = data.activeGradientNum;
            
        }
    }


    public void SetGradient ( Gradient grad, int num )
    {
        activeGradient = grad;
        activeGradientNum = num;
    }


    // Update is called once per frame
    void Update ( )
    {

    }


    public void SetHighScores ( HighScoreFormat[] newScores )
    {
        highScores = newScores;
        Save();
    }



    public void Save ( )
    {
        Rain_Saving.SaveFRain(this);
    }

}
