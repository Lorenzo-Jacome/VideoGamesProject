
/*
Created by: Maximiliano Sapién
Description: Script assigned to a camera and used to follow the player
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float cameraDistance = 30.0f;

    void Awake ()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
    void FixedUpdate() 
    { 
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z); 
    }
}
