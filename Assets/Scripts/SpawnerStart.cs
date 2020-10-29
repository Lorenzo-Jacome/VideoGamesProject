
/*
By: Maximiliano Sapién
Description: Instantiates objects in the world
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStart : MonoBehaviour
{
    public GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(start, transform.position, Quaternion.identity);
    }
}
