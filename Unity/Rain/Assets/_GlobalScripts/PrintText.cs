﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintText : MonoBehaviour
{

    public TextMeshProUGUI tmp;

    public int framesBetweenLetters = 3;

    private string instructions;

    // Start is called before the first frame update
    void Start ()
    {

    }


    public void OnActivation ()
    {
        instructions = tmp.text;
        tmp.text = "";
        StartCoroutine(WriteInstructions());
    }

    IEnumerator WriteInstructions ()
    {
        int length = instructions.Length;
        for ( int i = 0; i <= length; i++ )
        {
            tmp.text = instructions.Substring(0, i);


            for ( int j = 0; j < framesBetweenLetters; j++ )
            {
                yield return null;
            }
        }
    }


    // Update is called once per frame
    void Update ()
    {

    }
}
