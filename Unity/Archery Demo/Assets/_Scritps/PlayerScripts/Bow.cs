using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Tooltip("(Optional) The quiver this bow uses for references to arrows and how many arrows are left ti fire")]
    public BowQuiver quiver;

    [Tooltip("The current arrow prefab being used. If there is no quiver attached to this script, this is the arrow prefab " +
        "the bow will use and fire")]
    public GameObject arrowPrefab;

    [Tooltip("What GameObject the arrow will spawn at")]
    public GameObject arrowSpawnPoint;

    [Tooltip("The max speed in meters per second arrows will fire at when the bow is at full power")]
    public float maxArrowForce = 90;

    private float arrowForce = 0; // The current force to be applied to the arrow. Builds up to the maxArrowForce as the bow is pulled back

    [Tooltip("How many seconds after an arrow is fired will the next arrow spawn")]
    public float arrowSpawnTime = 1.5f;

    private GameObject arrow; // The current arrow being held by the bow

    bool canPullBack = true; // Is the player able to pull back the bow
    bool isTension = false; // Is the bow currently under tension
    bool isWaitingForSpawner = false;

    public Animation anim;

    private AudioSource audioSource;
    public AudioClip pullBack;
    public AudioClip release;



    // Start is called before the first frame update
    void Start ( )
    {
        if ( quiver )
            arrowPrefab = quiver.GetArrow();

        audioSource = GetComponent<AudioSource>();

        SpawnArrow();
    }

    // Update is called once per frame
    void Update ( )
    {
        if ( Input.GetMouseButtonDown(0) && canPullBack )
        {
            StartCoroutine(TensionBuildUp());
        }

        if (  arrow )
        {
            arrow.transform.position = arrowSpawnPoint.transform.position;
            arrow.transform.rotation = arrowSpawnPoint.transform.rotation;
        }

        if ( quiver && !isTension)
        {
            GetInputForQuiver();
        }

    }

    private void GetInputForQuiver ( )
    {
        if ( Input.GetKeyDown(KeyCode.E) )
        {
            quiver.SwitchRight();
            if ( !isWaitingForSpawner )
            {
                Destroy(arrow);
                SpawnArrow();
            }
        }
        if ( Input.GetKeyDown(KeyCode.Q) )
        {
            quiver.SwitchLeft();

            if ( !isWaitingForSpawner )
            {
                Destroy(arrow);
                SpawnArrow();
            }
        }
    }


    private IEnumerator TensionBuildUp ( )
    {
        isTension = true;

        audioSource.PlayOneShot(pullBack);

        anim.Play("Copper_Bow_Armature|Draw");
        anim.PlayQueued("Copper_Bow_Armature|Hold");
        anim.clip = anim.GetClip("Copper_Bow_Armature|Hold");
        while ( !Input.GetMouseButtonUp(0) ) // Builds up pressure as long as the mouse button is held down
        {
            if ( arrowForce < maxArrowForce)
                arrowForce += .75f;
            yield return null;
        }

        audioSource.PlayOneShot(release);

        anim.Play("Copper_Bow_Armature|Fire");
        anim.clip = anim.GetClip("Copper_Bow_Armature|Idle");
        
        canPullBack = false;
        isTension = false;
        arrow.transform.parent = null;

        arrow.GetComponent<Arrow>().Fire(arrowForce);
        arrow = null;
        if ( quiver )
            quiver.DecreaseShotsLeft();

        arrowForce = 0;
        isWaitingForSpawner = true;
        Invoke("SpawnArrow", arrowSpawnTime);
    }



    private void SpawnArrow ( )
    {
        isWaitingForSpawner = false;
        if ( quiver )
        {
            arrowPrefab = quiver.GetArrow();
            if ( quiver.ShotsLeft() < 1 )
            {
                //Debug.Log("In SpawnArrow, ArrowPrefab:  " + arrowPrefab + "   arrow: " + quiver.arrowIndex);
                return;
            }
        }

        //Debug.Log("In SpawnArrow after if, ArrowPrefab:  " + arrowPrefab + "   arrow: " + quiver.arrowIndex);

        arrow = Instantiate(arrowPrefab, arrowSpawnPoint.transform.position, arrowSpawnPoint.transform.rotation) as GameObject;
        arrow.transform.parent = arrowSpawnPoint.transform;

        canPullBack = true;
    }


}
