using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICover : MonoBehaviour
{

   public void ChangeActiveState ( )
   {
      this.gameObject.SetActive(!gameObject.activeSelf); 
   }

}
