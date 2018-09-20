using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (WinPlatform.s_ActivatedWinPlatforms == WinPlatform.s_NumberOfWinPlatforms)
            Debug.Log("You win!!!!!!");
    }
}
