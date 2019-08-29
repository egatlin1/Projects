using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowQuiver : MonoBehaviour
{

    //public GameObject[] arrowPrefabs;

    //[Tooltip("How many arrows the player has in their quiver. If set to -1, the player will have infinate arrows")]
    //public int numOfArrows;
    public int arrowIndex = 0;
    public ArrowTypes[] arrows;


    private int[] initialArrowCounts;


    // Start is called before the first frame update
    void Awake()
    {
        initialArrowCounts = new int[arrows.Length];
        for ( int i = 0; i < arrows.Length; i++ )
        {
            if ( arrows[i].numOfArrows == -1 )
                arrows[i].numOfArrows = int.MaxValue;
            initialArrowCounts[i] = arrows[i].numOfArrows;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ResetQuiver ( )
    {
        for ( int i = 0; i < arrows.Length; i++ )
        {
            arrows[i].numOfArrows = initialArrowCounts[i];
        }
    }


    public GameObject GetArrow ( )
    {
        return arrows[arrowIndex].arrow;
    }

    public void DecreaseShotsLeft ( )
    {
        arrows[arrowIndex].numOfArrows--;
    }


    public int ShotsLeft ( )
    {
        return arrows[arrowIndex].numOfArrows;
    }

    public void SwitchRight ( )
    {
        arrowIndex++;
        arrowIndex = arrowIndex % arrows.Length;

        if ( ShotsLeft() == 0 )
        {
            for ( int i = 0; i < arrows.Length; i++ )
            {
                arrowIndex++;
                arrowIndex = arrowIndex % arrows.Length;

                if ( ShotsLeft() != 0 )
                {
                    break;
                }
            }
            if ( ShotsLeft() == 0 )
                arrowIndex = 0;
        }

        
    }

    public void SwitchLeft ( )
    {
        arrowIndex--;
        arrowIndex = arrowIndex % arrows.Length;
        if ( arrowIndex < 0 )
            arrowIndex = arrows.Length - 1;


        if ( ShotsLeft() == 0 )
        {
            for ( int i = 0; i < arrows.Length; i++ )
            {
                arrowIndex--;
                arrowIndex = arrowIndex % arrows.Length;
                if ( arrowIndex < 0 )
                    arrowIndex = arrows.Length - 1;

                if ( ShotsLeft() != 0 )
                {
                    break;
                }
            }
            if ( ShotsLeft() == 0 )
                arrowIndex = 0;
        }
    }


}



[System.Serializable]
public struct ArrowTypes
{
    
    public GameObject arrow;
    [Tooltip("How many arrows the player has in their quiver. If set to -1, the player will have infinate arrows")]
    public int numOfArrows;
    [Tooltip("UI image to represent this arrow")]
    public Image arrowImage;

}
