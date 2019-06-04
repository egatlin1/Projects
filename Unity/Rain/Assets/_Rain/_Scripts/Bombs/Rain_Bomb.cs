using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_Bomb : MonoBehaviour
{

    public float minSize = 1.5f;
    public float maxSize = 3f;

    public float minFallSpeed = .5f;
    public float maxFallSpeed = 1.75f;

    public bool doesLoseLifeOnDeath = true;


    private float fallSpeed;


    // Start is called before the first frame update
    void Awake ( )
    {
        
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, 1);
    }

    

    // Update is called once per frame
    void Update ( )
    {
        transform.Translate(0, -fallSpeed * Time.deltaTime, 0);
    }


    private void OnTriggerEnter2D ( Collider2D collision )
    {

        if ( collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            OnDeath();
        }
    }

    public virtual void OnDeath ( )
    {
        
        Rain_ScoreKeeper.instance.AddScore();
        Destroy(gameObject);
    }

}
