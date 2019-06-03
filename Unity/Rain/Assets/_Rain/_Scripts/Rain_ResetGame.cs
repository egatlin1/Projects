using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_ResetGame : MonoBehaviour
{
    public Rain_BombSpawner spawner;


    public GameObject level;
    public GameObject credits;

    public ParticleSystem fireworks;

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
        yield return new WaitForSeconds(1);
        credits.SetActive(false);
        yield return new WaitForSeconds(1);

        while ( Camera.main.transform.position.y < 0 )
        {
            Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, new Vector3(0, 0, -10), Time.deltaTime);
            if ( Vector3.Distance(Camera.main.transform.position, new Vector3(0, 0, -10)) < .1f )
                Camera.main.transform.position = new Vector3(0, 0, -10);
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
