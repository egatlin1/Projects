using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicManager : MonoBehaviour
{
    [Tooltip("Starting positions for the moving targets to spawn")]
    public Transform[] targetStartingPositions;
    [Tooltip("Ending positions for the moving targets to move towards")]
    public Transform[] targetEndingPositions;


    public GameObject movingTargetPrefab;

    public GameObject[] startGameTargets;

    private BowQuiver quiver;


    private float targetMovementSpeed;
    private float targetSpawnRate;
    private float minTargetSpawnRate;
    private float targetSpawnRateDecrease;
    
    // Start is called before the first frame update
    void Start()
    {
        quiver = FindObjectOfType<BowQuiver>();
    }



    public void StartGame ( int difficulty )
    {
        SetDifficultySettings(difficulty);
        StartGameTargetState(false);
        Score.Instance.ResetScore();

        quiver.ResetQuiver();
        StartCoroutine(Game());
    }


    private void SetDifficultySettings ( int dif )
    {
        switch ( dif )
        {

            case 0 : // easy
                Debug.Log("Easy");
                targetMovementSpeed = 2;
                targetSpawnRate = 5;
                minTargetSpawnRate = 2.5f;
                targetSpawnRateDecrease = 0.05f;

                break;
            case 1 : // medium
                Debug.Log("Medium");
                targetMovementSpeed = 3;
                targetSpawnRate = 4;
                minTargetSpawnRate = 2f;
                targetSpawnRateDecrease = 0.075f;

                break;
            case 2 : // hard
                Debug.Log("Hard");
                targetMovementSpeed = 5;
                targetSpawnRate = 4;
                minTargetSpawnRate = 2f;
                targetSpawnRateDecrease = 0.125f;

                break;
            
        }
    }


    private void StartGameTargetState ( bool state )
    {
        for ( int i = 0; i < startGameTargets.Length; i++ )
        {
            startGameTargets[i].SetActive(state);
        }
    }

    IEnumerator Game ( )
    {
        while (true)
        {

            for ( int i = 0; i < targetStartingPositions.Length; i++ )
            {
                int num = Random.Range(0, 2);
                if ( num == 1 )
                {
                    GameObject target = Instantiate(movingTargetPrefab, targetStartingPositions[i].position, targetStartingPositions[i].rotation) as GameObject;


                    MovingTarget movingTarget = target.GetComponentInChildren<MovingTarget>();
                    movingTarget.target = targetEndingPositions[i];
                    movingTarget.speed = targetMovementSpeed;
                }
            }

            if ( targetSpawnRate > minTargetSpawnRate )
            {
                targetSpawnRate -= targetSpawnRateDecrease;
            }

            yield return new WaitForSeconds(targetSpawnRate);
        }
    }


    public void EndGame ( )
    {
        StopAllCoroutines();
        quiver.ResetQuiver(); // reset the players quiver to the starting value from when they entered the scene

        MovingTarget[] targets = FindObjectsOfType<MovingTarget>();

        // TODO: optimize this!
        foreach ( MovingTarget item in targets )
        {
            Destroy(item.transform.parent.gameObject);
        }
        StartGameTargetState(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter ( Collider other )
    {
        if ( other.tag == "Target" )
        {
            EndGame();
        }
    }



}
