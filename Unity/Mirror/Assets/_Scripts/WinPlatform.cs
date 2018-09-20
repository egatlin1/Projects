using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
    public static int s_NumberOfWinPlatforms = 0;
    public static int s_ActivatedWinPlatforms = 0;

    private bool isActivated = false;

    // Use this for initialization
    void Awake ( )
    {
        WinPlatform.s_NumberOfWinPlatforms++;
    }


    private void OnTriggerEnter2D ( Collider2D other )
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player && !isActivated)
        {
            WinPlatform.s_ActivatedWinPlatforms++;
            isActivated = true;
            Debug.Log("Triggered");
        }
    }

    private void OnTriggerExit2D ( Collider2D other )
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player && isActivated )
        {
            WinPlatform.s_ActivatedWinPlatforms--;
            Debug.Log("Exited");
            isActivated = false;
        }
    }
}
