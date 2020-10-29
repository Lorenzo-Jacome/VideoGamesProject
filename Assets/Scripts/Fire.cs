
/*
By: Maximiliano Sapién
Description: Action of shooting by the player
*/
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public float delay;
    float nextShot = 0;
    public MotionRB player;
    public float ang;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        //Rotate an empty object that represents the gun angle:
        //RestaMP is relation between pointer and player and it's calculated in other script.
       if(Input.GetButtonDown("Fire1"))
       {
           if (Time.time > nextShot)
           {
               ang = Mathf.Atan2(player.restaMP.y,player.restaMP.x) * Mathf.Rad2Deg;
               bulletSpawn.rotation = Quaternion.Euler(0,0,ang);
               Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
               nextShot = Time.time + delay;
           }
       } 
    }
}
