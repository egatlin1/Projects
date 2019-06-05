using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rain_Player : MonoBehaviour
{

    #region PublicVariables
    public float colorChangeSpeed = 0.0005f;


    public GameObject bullet;
    public SpriteRenderer[] sRenderers;
    public Gradient gradient;
    public GameObject pauseMenu;

    public Slider snipperShotSlider;
    public float snipperShotDuration = 20;
    public Slider blanketShotSlider;
    public float blanketShotDuration = 10;
    public Slider rapidShotSlider;
    public float rapidShotDuration = 15;
    #endregion

    #region PrivateVariables
    private float blanketShotTime = 0;
    private float snipperShotTime = 0;
    private float rapidShotTime = 0;
    #endregion

    #region Singleton

    public static Rain_Player instance;

    private void Awake ()
    {
        instance = this;
    }

    #endregion



    // Start is called before the first frame update
    void Start ( )
    {
        StartCoroutine(ColorCycle());

        snipperShotSlider.maxValue = snipperShotDuration;
        blanketShotSlider.maxValue = blanketShotDuration;
        rapidShotSlider.maxValue = rapidShotDuration;
        gradient = FindObjectOfType<Rain_GameManager>().GetActiveGradient();
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( pauseMenu.activeSelf )
            return;

        if ( Input.GetMouseButtonDown(0) && !Rain_Lives.instance.IsGameOver() )
        {
            SpawnBullet();
        }
        if ( rapidShotTime > 0 && Input.GetMouseButtonUp(0) && !Rain_Lives.instance.IsGameOver() )
        {
            SpawnBullet();
        }

        AdjustTimers();

    }

    /*
     * Adjusts the timers of the abilities
     * Adjusts the sliders on screen to represent time left on abilities
     */
    private void AdjustTimers ( )
    {
        if ( blanketShotTime > 0 )
            blanketShotTime -= Time.deltaTime;
        if ( snipperShotTime > 0 )
            snipperShotTime -= Time.deltaTime;
        if ( rapidShotTime > 0 )
            rapidShotTime -= Time.deltaTime;

        snipperShotSlider.value = snipperShotTime;
        blanketShotSlider.value = blanketShotTime;
        rapidShotSlider.value = rapidShotTime;
    }




    /*
     * in change of spawning bullets
     */
    private void SpawnBullet ( )
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePos = new Vector2(mousePosition.x - transform.position.x,
                                       mousePosition.y - transform.position.y);
        GameObject bull = Instantiate(bullet, transform.position, transform.rotation);

        if ( snipperShotTime > 0 )
            bull.GetComponent<Rain_Bullet>().speed *= 3;

        bull.GetComponent<Rain_Bullet>().SetHeading(mousePos, sRenderers[0].color);


        if ( blanketShotTime > 0 )
        {
            bull.transform.localScale = new Vector3(.75f, .75f);
            SpreadShot(mousePosition);
        }
    }


    /*
     * spawns extra bullets when this ability is activated
     */
    private void SpreadShot ( Vector2 mousePosition )
    {

        Vector2 mousePos = new Vector2(mousePosition.x - transform.position.x + 20,
                                       mousePosition.y - transform.position.y);

        GameObject bull = Instantiate(bullet, transform.position, transform.rotation);
        bull.GetComponent<Rain_Bullet>().SetHeading(mousePos, sRenderers[0].color);
        bull.transform.localScale = new Vector3(.75f, .75f);


        mousePos = new Vector2(mousePosition.x - transform.position.x - 20,
                               mousePosition.y - transform.position.y);

        bull = Instantiate(bullet, transform.position, transform.rotation);
        bull.GetComponent<Rain_Bullet>().SetHeading(mousePos, sRenderers[0].color);
        bull.transform.localScale = new Vector3(.75f, .75f);    

    }

    IEnumerator ColorCycle ( )
    {
        float colorNum = 0.0f;
        while ( true )
        {
            if ( pauseMenu.activeSelf)
            {
                yield return null;
                continue;
            }

            for ( int i = 0; i < sRenderers.Length; i++ )
            {
                sRenderers[i].color = gradient.Evaluate(colorNum % 1);
                sRenderers[i].color = new Color ( sRenderers[i].color.r, 
                                                  sRenderers[i].color.g, 
                                                  sRenderers[i].color.b, 
                                                  sRenderers[i].color.a - ( .2f * i) );
            }
            colorNum += colorChangeSpeed;
            yield return null;
        }
    }


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //          Activating abilities methods
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    public void StartBlanketShot ( )
    {
        blanketShotTime = blanketShotDuration;
        rapidShotTime = 0;
    }


    public void StartSnipperShot ( )
    {
        snipperShotTime = snipperShotDuration;
    }

    public void StartRapidShot ( )
    {
        rapidShotTime = rapidShotDuration;
        blanketShotTime = 0;
    }


    public void ResetAllAbilities ( )
    {
        rapidShotTime = 0;
        blanketShotTime = 0;
        snipperShotTime = 0;
    }

}
