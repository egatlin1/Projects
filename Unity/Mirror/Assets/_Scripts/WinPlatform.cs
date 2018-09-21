using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
    EventHandler eventHandler;

    private bool isActivated = false;

    // Use this for initialization
    void Awake ( )
    {
        eventHandler = FindObjectOfType<EventHandler>();
        if (!eventHandler)
            Debug.LogWarning("No EventHandler found");
        eventHandler.RegisterPlatform();
    }


    private void OnTriggerEnter2D ( Collider2D other )
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player && !isActivated)
        {
            eventHandler.PlatformActivated();
            isActivated = true;
            //Debug.Log("Triggered");
            //Debug.Log("number of platforms: " + WinPlatform.s_NumberOfWinPlatforms);
            //Debug.Log("number of activated platforms: " + WinPlatform.s_ActivatedWinPlatforms);
        }
    }

    private void OnTriggerExit2D ( Collider2D other )
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player && isActivated )
        {
            eventHandler.PlatformDeactivated();
            Debug.Log("Exited");
            isActivated = false;
        }
    }
}
