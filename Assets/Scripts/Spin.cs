
/*
By: Maximiliano Sapién
Description: Used to rotate proyectiles when it is needed. 
*/
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 rotation;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation);
    }
}
