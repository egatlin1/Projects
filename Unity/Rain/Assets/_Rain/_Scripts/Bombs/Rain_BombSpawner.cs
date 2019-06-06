using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BombSpawner : MonoBehaviour
{

    #region PublicVariables
    public float time;
    public float spawnRangeX = 5f;
    public float spawnRangeY = .5f;

    public float maxTimeBetweenBombs = 1.5f;
    public float minTimeBetweenBombs = .1f;
    public float reducitonTime = 0.005f;
    #endregion

    #region Bombs
    public GameObject bomb;
    public GameObject healthBomb;
    public GameObject snipperBomb;
    public GameObject blanketBomb;
    public GameObject rapidBomb;
    public GameObject bigBomb;
    public GameObject fullAutoBomb;
    #endregion

    private bool hasUpgraded = false;
    private bool canSpawnBigBombs = false;


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
                               Rain_ScoreKeeper.instance.GetScore() == 200 ||
                               Rain_ScoreKeeper.instance.GetScore() == 250  ||
                               Rain_ScoreKeeper.instance.GetScore() == 300 ) )
        {
            if ( Rain_ScoreKeeper.instance.GetScore() == 250 )
            {
                canSpawnBigBombs = true;
                reducitonTime *= 2;
                time *= 2;
            }
            else
                reducitonTime -= reducitonTime * .5f;
            hasUpgraded = true;
        }
        else if ( hasUpgraded && ( Rain_ScoreKeeper.instance.GetScore() == 51 ||
                                   Rain_ScoreKeeper.instance.GetScore() == 101 ||
                                   Rain_ScoreKeeper.instance.GetScore() == 201 ||
                                   Rain_ScoreKeeper.instance.GetScore() == 251 ||
                                   Rain_ScoreKeeper.instance.GetScore() == 301 ) ) 
            hasUpgraded = false;
    }


    private void SpawnBomb ( )
    {
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-spawnRangeX, spawnRangeX),
                                  transform.position.y + Random.Range(-spawnRangeY, spawnRangeY));

        int rand = Random.Range(1, 1001); // 1-100


        Instantiate(PickBomb(rand), pos, transform.rotation);

    }

    private GameObject PickBomb ( int rand )
    {
        if ( rand >= 10 && rand <= 20 ) // 2% chance
        {
            return healthBomb;
            // red
        }
        else if ( rand >= 200 && rand <= 202 && Rain_ScoreKeeper.instance.GetScore() >= 200 ) // .2% chance
        {
            return blanketBomb;
            // cyan
        }
        else if ( rand >= 300 && rand <= 315 ) // 1.5% chance
        {
            return snipperBomb;
            // magenta
        }
        else if ( rand >= 400 && rand <= 407 ) // .7%
        {
            return rapidBomb;
            // yellow
        }
        else if ( rand >= 500 && rand <= 525 ) // 2.5%
        {
            return fullAutoBomb;
            // green
        }
        else if ( canSpawnBigBombs && rand >= 700 && rand <= 950 ) // 25%
        {
            return bigBomb;
            // gray
        }
        else
        {
            return bomb;
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

        }
    }

}
