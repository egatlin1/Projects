using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clapping : MonoBehaviour
{

   private Animator anim;

   // Use this for initialization
   void Start ( )
   {
      anim = GetComponent<Animator>();

      anim.speed = Random.Range(.75f, 5f);
   }

   // Update is called once per frame
   void Update ( )
   {

   }
}
