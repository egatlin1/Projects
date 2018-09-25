using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SassBot : MonoBehaviour
{
    public Text text;
    public string[] sassyText;

    // Use this for initialization
    void Awake ( )
    {
        if (!text)
            Debug.LogError("SassBot needs a Text Element ASAP!");


        if (sassyText.Length == 0)
        { }
        else if (sassyText.Length == 1)
            text.text = sassyText[0];
        else
        {
            text.text = sassyText[Random.Range(0, sassyText.Length)];
        }
    }

}
