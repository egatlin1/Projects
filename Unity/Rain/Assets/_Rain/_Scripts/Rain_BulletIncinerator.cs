﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_BulletIncinerator : MonoBehaviour
{
    private void OnTriggerExit2D ( Collider2D collision )
    {

        if ( collision.tag == "Bullet" )
        {
            Destroy(collision.gameObject);
        }
    }
}
