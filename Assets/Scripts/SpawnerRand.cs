
/*
By: Maximiliano Sapién
Description: Array where its components are called randomly. So it can be used to spawn enemies or generate the level.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRand : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }
}
