﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserDamage : MonoBehaviour
{
    public int damage;
    
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals ("Player"))
        {
            col.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}