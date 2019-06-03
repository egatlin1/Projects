using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_ResetGame : MonoBehaviour
{
    public Rain_BombSpawner spawner;


    public GameObject level;
    public GameObject credits;
    public GameObject clearBombs;

    public ParticleSystem fireworks;
    public SpriteRenderer fadeScreen;


    private float spawnerReducitonTime;
    private int startingLives;


    // Start is called before the first frame update
    void Start()
    {
        spawnerReducitonTime = spawner.reducitonTime;
        startingLives = Rain_Lives.instance.lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonResponse ( )
    {
        StartCoroutine(ResetGame()); 
    }


    IEnumerator ResetGame ( )
    {

        Rain_Player.instance.ResetAllAbilities();

        fireworks.Stop();
        clearBombs.SetActive(true);
        credits.SetActive(false);
        yield return new WaitForSeconds(1f);
        clearBombs.SetActive(false);

        while ( fadeScreen.color.a > 0 )
        {

            fadeScreen.color = new Color(fadeScreen.color.r,
                                         fadeScreen.color.g,
                                         fadeScreen.color.b,
                                         fadeScreen.color.a - .01f);
            yield return null;
        }

        yield return new WaitForSeconds(2);

        Rain_Lives.instance.ResetWithLives(startingLives);
        Rain_ScoreKeeper.instance.ResetScore();
        yield return new WaitForSeconds(1);
        level.SetActive(true);
        spawner.StartGame();
    }



}
