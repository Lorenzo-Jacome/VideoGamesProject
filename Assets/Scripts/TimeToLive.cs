﻿
/*
By: Maximiliano Sapién
Description: Mainly used to specify the duration of a bullet in the world.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    public float timeToLive;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
