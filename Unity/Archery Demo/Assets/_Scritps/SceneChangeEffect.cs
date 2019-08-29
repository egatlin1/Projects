using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeEffect : MonoBehaviour
{

    public List<GameObject> screenCovers;

    public float coverMoveSpeed = 300;

    public float endingHeight;

    public float minTimeBetween = .1f;
    public float maxTimeBetween = .5f;


    int numMoving = 0;

    // Start is called before the first frame update
    void Start()
    {
        //PlayEffect(DisplayMessage);
    }

    void DisplayMessage ( )
    {
        Debug.Log("Test Ended");
    }


    public void PlayEffect ( System.Action callBack )
    {
        StartCoroutine(PlayEffects(callBack));
    }



    IEnumerator PlayEffects ( System.Action callBack )
    {

        int counter = screenCovers.Count;
        for ( int i = 0; i < counter; i++ )
        {
            int num = Random.Range(0, screenCovers.Count);
            StartCoroutine(MoveUp(screenCovers[num]));
            screenCovers.RemoveAt(num);
            yield return new WaitForSeconds(Random.Range(minTimeBetween, maxTimeBetween));
        }


        while (numMoving != 0 )
        {
            yield return null;
        }
        callBack();
    }


    IEnumerator MoveUp ( GameObject obj )
    {
        
        numMoving++;
        while ( obj.transform.position.y < endingHeight )
        {
            obj.transform.Translate(0, coverMoveSpeed * Time.deltaTime, 0);
            yield return null;
        }
        numMoving--;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
