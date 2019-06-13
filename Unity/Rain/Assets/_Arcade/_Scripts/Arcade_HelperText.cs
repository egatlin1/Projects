using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Arcade_HelperText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image background;
    public GameObject shop;

    #region Singleton
    public static Arcade_HelperText instance;

    private void Awake ()
    {
        instance = this;
    }
    #endregion


    // Start is called before the first frame update
    void Start ()
    {

        text = GetComponent<TextMeshProUGUI>();
        //text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        //background.color = new Color(background.color.r, background.color.g, background.color.b, text.color.a);

        text.text = "";
    }

    private void Update ()
    {

    }



    public void DisplayTest ( string text )
    {
        this.text.text = text;

        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn ()
    {
        while ( text.color.a < 1 )
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + .05f);
            background.color = new Color(background.color.r, background.color.g, background.color.b, text.color.a);
            yield return null;
        }
    }

    public void DisableText ()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut ()
    {
        while ( text.color.a > 0 )
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - .05f);
            background.color = new Color(background.color.r, background.color.g, background.color.b, text.color.a);
            yield return null;
        }
    }

}
