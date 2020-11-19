
/*
By: Maximiliano Sapién
Description: Damages enemy when a bullet hits the enemy.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;
//When there's a collition with gameObject enemy, it takes life out of enemy.
    void OnCollisionEnter2D(Collision2D col)
    {
        print("coll");
        if(col.gameObject.tag == "Enemy")
        {
            print("enemy");
            col.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Walls")
        {
            print("walls");
            Destroy(gameObject);
        }
    }
}
