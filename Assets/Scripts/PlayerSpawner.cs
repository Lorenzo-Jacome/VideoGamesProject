
/*
By: Maximiliano Sapién
Description: It instantiates the player in the level. Goes attached to the spawner gameObject
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
