
/*
Creator: Maximiliano Sapién
Description: It damages the player when taking contact with the enemy
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
