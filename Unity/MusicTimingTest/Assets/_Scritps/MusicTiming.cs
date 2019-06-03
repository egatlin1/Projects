using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTiming : MonoBehaviour
{
    public int BPM;
    public int skipBeats;

    public AudioClip song;
    AudioSource audioSource;

    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    public float secondsBetweenBeats;
    public int switchAttack = 0;
    public int switchState = 0;

    public int count;
    public int state;

    // Start is called before the first frame update
    void Start ( )
    {

        secondsBetweenBeats = (float)(60f / BPM);


        audioSource = GetComponent<AudioSource>();
        
    }


    public void StartGame ( )
    {
        StartCoroutine(FSM());
    }


    IEnumerator FSM ( )
    {
        if ( switchAttack == 0 )
            switchAttack = int.MaxValue;
        if ( switchState == 0 )
            switchState = int.MaxValue;

        count = 0;
        state = 0;
        audioSource.PlayOneShot(song);
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(secondsBetweenBeats * skipBeats);
            count++;
            if ( count == switchState )
            {
                state++;
                count = 0;
            }
            if ( state == 2 )
                state = 0;

            switch ( state )
            {
                case 0:
                    StateOne(count);
                    break;
                case 1:
                    StateTwo(count);
                    break;
            }

        }
    }


    private void StateOne ( int count )
    {
        if ( count % switchAttack == 0 )
            SpawnMany();
        else
            Rezise(Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject);
    }


    public void StateTwo ( int count )
    {
        if ( count % switchAttack == 0 )
        {
            SpawnStraighShot();
        }
        else
        {
            SpawnMany();
        }
    }

    public void SpawnMany ( )
    {
        Rezise(Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject);
        GameObject ball = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
        Rezise(ball);
        ball.transform.eulerAngles = Quaternion.Euler(ball.transform.eulerAngles.x, ball.transform.eulerAngles.y + 90, ball.transform.eulerAngles.z).eulerAngles;
        ball = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
        ball.transform.eulerAngles = Quaternion.Euler(ball.transform.eulerAngles.x, ball.transform.eulerAngles.y - 90, ball.transform.eulerAngles.z).eulerAngles;
        Rezise(ball);
    }

    public void SpawnStraighShot ( )
    {
        Rezise(Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject);
        Rezise(Instantiate(bullet, bulletSpawnPoint.transform.position + Vector3.forward, bulletSpawnPoint.transform.rotation) as GameObject);
        Rezise(Instantiate(bullet, bulletSpawnPoint.transform.position - Vector3.forward, bulletSpawnPoint.transform.rotation) as GameObject);
    }


    private void Rezise( GameObject obj)
    {
        float volume = audioSource.volume;
        if ( volume < .1f )
            volume = .1f;


        obj.transform.localScale = Vector3.one * volume * .25f;
    }

}
