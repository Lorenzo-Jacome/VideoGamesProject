using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneScript : MonoBehaviour
{
    public float speed;
    public Transform obj;
    bool goRight = true;
    public GameObject laser;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(goRight){
            Vector3 tempVect = new Vector3(speed, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            obj.transform.position += tempVect;
        } else {
            Vector3 tempVect = new Vector3(-speed, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            obj.transform.position += tempVect;
        }

        laser.transform.localScale += new Vector3(0,1,0);

    }

    void OnCollisionEnter2D(Collision2D col){
        if(goRight){
            goRight = false;
        } else {
            goRight = true;
        }
    }
}
