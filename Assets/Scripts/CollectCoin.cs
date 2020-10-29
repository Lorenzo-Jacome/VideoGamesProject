
/*
Description: Used to trigger actions in the world by items.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    /* void OnCollisionEnter2D(Collision2D col)
    //{
    //    print("COLLIDED WITH " + col.gameObject.name);
    } */

    void OnTriggerEnter2D(Collider2D col)
    {
        print("TRIGGERED BY " + col.gameObject.name);
    }
}
