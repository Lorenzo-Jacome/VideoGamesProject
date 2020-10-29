using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitingDead : MonoBehaviour
{
    public GameObject canvas;
    bool found = false;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GameObject PlayerChar = GameObject.Find("PlayerChar");
        if (PlayerChar != null && found == false)
        {
            found = true;
        }

        if (PlayerChar == null && found == true && active == false)
        {
            Instantiate(canvas, transform.position, Quaternion.identity);
            active = true;
        }
        
    }
}
