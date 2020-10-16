using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlayerDetection : MonoBehaviour
{
    public ParticleSystem found;
    Rigidbody2D rb;
    Vector3 motion;
    public float speed;
    bool facingRight = true;
    bool active = false;
    int alt = 1;
    bool counting = false;
    int sideForce = 0;
    public GameObject player;
    public GameObject enemy;
    Vector3 player_relative_to_enemy;
    double playerColl = 0;
    public Animator animator;
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        
        motion.x = rb.velocity.x;
        motion.y = rb.velocity.y;
        //start fast
        if (start == false && active == true)
        {
            if (alt == 2)
            {
                sideForce = 1;
                alt++;
            }
            else
            {
                sideForce = -1;
                alt++;
            }
            start = true;
        }

        //contador
        if (active == true && counting == false)
        {
            counting = true;
            StartCoroutine(SwitchSide());
        }

        //fuerza x
        if (active == true) 
        {
            motion.x = sideForce * speed;
        }

        //voltear
        if (motion.x > 0 && !facingRight)
        {
            facingRight = true;
            transform.Rotate(0, 180, 0);
        }
        
        if (motion.x < 0 && facingRight)
        {
            facingRight = false;
            transform.Rotate(0, 180, 0);
        }
        rb.velocity = motion;

        animator.SetFloat("speedx", motion.x);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (active == false)
            {
                found.Play();
                player_relative_to_enemy=enemy.transform.position - player.transform.position;
                playerColl = player_relative_to_enemy.x;
                if (playerColl > 0)
                {
                    alt = 1;
                }
                else
                {
                    alt = 2;
                }
                //Debug.Log(player_relative_to_enemy.ToString());
            }
            active = true;
        }
    }

    public IEnumerator SwitchSide()
    {
        if (alt > 2)
        {
            alt = 1;
        }
        if (alt == 2)
        {
            yield return new WaitForSeconds(2f);
            counting = false;
            sideForce = 1;
            alt++;
            //print("player detected if 0");
        }
        else
        {
            yield return new WaitForSeconds(2f);
            counting = false;
            sideForce = -1;
            alt++;
            //print("player detected else");
        }
    }
}
