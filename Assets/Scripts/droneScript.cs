
/*
By: Lorenzo Jácome
Description: Manges everything related to the drone health, drone movement, and its laser.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneScript : MonoBehaviour
{
    public float speed;
    public Transform obj;
    bool goRight = true;
    public GameObject laser;
    float laserScale;
    public float laserScaleLimit;
    public int laserSpeed;
    bool laserShoots = false;
    public float laserTime;
    public int maxHealth;
    int health;
    public int damage;


    void Start()
    {
        StartCoroutine(shootLaser());
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement code:
        if(goRight){
            Vector3 tempVect = new Vector3(speed * Time.deltaTime, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            obj.transform.position += tempVect;
        } else {
            Vector3 tempVect = new Vector3(-speed * Time.deltaTime, 0, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            obj.transform.position += tempVect;
        }

        //Laser code:
        //When it shoots, it increases the laser size in y till it hits the floor
        laserScale = laser.transform.localScale.y;
        if (laserScale < laserScaleLimit && laserShoots){
            laser.transform.localScale += new Vector3(0,laserSpeed * Time.deltaTime,0);
        }else if (!laserShoots && laserScale > 1){
            laser.transform.localScale += new Vector3(0,-laserSpeed * Time.deltaTime,0);
        }
    }
     //Detects when impacts a wall and changes direction
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Bullet"){
            health -= 1;
            if(health <= 0){
                Destroy(gameObject);
            }
        } else if(col.gameObject.tag == "Walls" || col.gameObject.tag == "Enemy"){
            if(goRight){
                goRight = false;
            } else {
                goRight = true;
            }
        }
    }
    //Find when the laser hits the ground, so it stops growing
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Ground")){
            laserScaleLimit = laser.transform.localScale.y;
        }
    }
    //When the laser stops touching the ground, it can increase again
    void OnTriggerExit2D(Collider2D col)
    {
        laserScaleLimit = 1000f;
    }

    public IEnumerator shootLaser(){
        while(true){
            yield return new WaitForSeconds(laserTime);
            laserShoots = true;
            laserScaleLimit = 1000f;
            yield return new WaitForSeconds(laserTime);
            laserShoots = false;
        }
    }
}
