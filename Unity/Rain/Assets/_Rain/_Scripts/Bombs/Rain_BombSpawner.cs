using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombSpawner : MonoBehaviour
{
    public float time;
    public float spawnRangeX = 5f;
    public float spawnRangeY = .5f;

    public float maxTimeBetweenBombs = 1.5f;
    public float minTimeBetweenBombs = .1f;
    public float reducitonTime = 0.005f;

    public GameObject bomb;
    public GameObject healthBomb;
    public GameObject snipperBomb;
    public GameObject blanketBomb;
    public GameObject rapidBomb;


    private bool hasUpgraded = false;

    // Start is called before the first frame update
    void Start ( )
    {
        StartGame();
    }


    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRangeX * 2, spawnRangeY * 2));

        
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( !hasUpgraded && ( Rain_ScoreKeeper.instance.GetScore() == 50 || 
                               Rain_ScoreKeeper.instance.GetScore() == 100 ||
                               Rain_ScoreKeeper.instance.GetScore() == 200 ) )
        {
            reducitonTime -= reducitonTime * .5f;
            hasUpgraded = true;
        }
        else if ( hasUpgraded && ( Rain_ScoreKeeper.instance.GetScore() == 51 ||
                                   Rain_ScoreKeeper.instance.GetScore() == 101 ||
                                   Rain_ScoreKeeper.instance.GetScore() == 201 ) ) 
            hasUpgraded = false;
    }


    private void SpawnBomb ( )
    {
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-spawnRangeX, spawnRangeX),
                                  transform.position.y + Random.Range(-spawnRangeY, spawnRangeY));

        int rand = Random.Range(1, 101); // 1-100

        if ( rand >= 1 && rand <= 3 ) // 3% chance
        {
            Instantiate(healthBomb, pos, transform.rotation);
            // red
        }
        else if ( rand >= 20 && rand <= 22 ) // 2% chance
        {
            Instantiate(blanketBomb, pos, transform.rotation);
            // cyan
        }
        else if ( rand >= 30 && rand <= 33 ) // 3% chance
        {
            Instantiate(snipperBomb, pos, transform.rotation);
            // magenta
        }
        else if ( rand >= 40 && rand <= 45 ) // 2%
        {
            Instantiate(rapidBomb, pos, transform.rotation);
            // yellow
        }
        else
        {
            Instantiate(bomb, pos, transform.rotation);
            // white
        }
        

    }


    public void StartGame ( )
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning ( )
    {
        time = maxTimeBetweenBombs;
        while ( true )
        {
            if ( Rain_Lives.instance.IsGameOver() )
                break;
            SpawnBomb();

            yield return new WaitForSeconds(time);
            if ( time > minTimeBetweenBombs )
                time -= reducitonTime;
            Debug.Log("Spawning");

        }
    }

}
