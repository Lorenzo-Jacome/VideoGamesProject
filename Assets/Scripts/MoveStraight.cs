
/*
By: Maximiliano Sapién
Description: Created to make bullets go to a direction infinitely
*/
using UnityEngine;

public class MoveStraight : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
