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

    void Start()
    {
        StartCoroutine(shootLaser());
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
        laserScale = laser.transform.localScale.y;
        if (laserScale < laserScaleLimit && laserShoots){
            laser.transform.localScale += new Vector3(0,laserSpeed * Time.deltaTime,0);
        }else if (!laserShoots && laserScale > 1){
            laser.transform.localScale += new Vector3(0,-laserSpeed * Time.deltaTime,0);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag != "Bullet")
        {
            if(goRight){
                goRight = false;
            } else {
                goRight = true;
            }
        }
    }

    public IEnumerator shootLaser(){
        while(true){
            yield return new WaitForSeconds(laserTime);
            laserShoots = true;
            yield return new WaitForSeconds(laserTime);
            laserShoots = false;
        }
    }
}
