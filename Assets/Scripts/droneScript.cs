using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneScript : MonoBehaviour
{
    [SerializeField] public float speed;
    public Transform obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempVect = new Vector3(speed, 0, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        obj.transform.position += tempVect;
    }
}
