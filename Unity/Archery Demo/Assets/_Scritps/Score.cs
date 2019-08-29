using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    [SerializeField]
    private int score = 0;

    private static Score _Instance;

    public static Score Instance
    {
        private set
        {
            if ( _Instance != null )
                Debug.LogWarning("Score::Instance ~ _Instance is is being reset");
            _Instance = value;
        }
        get
        {
            return _Instance;
        }
    }



    // Start is called before the first frame update
    void Start ( )
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        Instance = this;
        AddScore(0);
    }

    // Update is called once per frame
    void Update ( )
    {

    }


    public void AddScore ( int val )
    {
        score += val;
        textMeshPro.text = "Score: " + score;
    }


    public void ResetScore ( )
    {
        score = 0;
        textMeshPro.text = "Score: " + score;
    }

}
