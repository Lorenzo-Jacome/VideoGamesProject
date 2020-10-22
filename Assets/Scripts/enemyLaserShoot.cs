using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaserShoot : MonoBehaviour
{
    public GameObject bullet;
    float fireRate;
    float nextFire;
    
    public GameObject player;
    public GameObject enemy;
    Vector3 player_relative_to_enemy;
    double playerColl = 0;

    public float ang;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = .6f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }        
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if(this.gameObject.GetComponentInParent<EnemyPlayerDetection>().active == true)
        {
            player_relative_to_enemy=enemy.transform.position - player.transform.position;
            playerColl = player_relative_to_enemy.x;
            ang = Mathf.Atan2(player_relative_to_enemy.y,player_relative_to_enemy.x) * Mathf.Rad2Deg;
            this.gameObject.transform.rotation = Quaternion.Euler(0,0,ang);
            
            if (Time.time > nextFire && playerColl > 0 && playerColl < 8 && this.gameObject.GetComponentInParent<EnemyPlayerDetection>().alt == 1)
            {
                Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
                nextFire = Time.time + fireRate;
            }
            else if (Time.time > nextFire && playerColl < 0 && playerColl > -8 && this.gameObject.GetComponentInParent<EnemyPlayerDetection>().alt == 2)
            {
                Instantiate(bullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
                nextFire = Time.time + fireRate;
            }
        }
    }
}
