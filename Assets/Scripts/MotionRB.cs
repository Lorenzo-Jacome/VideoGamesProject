using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionRB : MonoBehaviour
{
    public ParticleSystem dustDir;
    public ParticleSystem dustLand;
    AudioSource audioSrc;
    public float speed;
    public Vector3 jumpForce;
    Vector3 motion;
    public Vector3 mousePosition;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public bool grounded;
    bool djump;
    bool facingRight = true;
    public Animator animator;
    public Camera cam;
    bool pesa;
    public Vector3 restaMP;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        grounded = false;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //HORIZONTALS
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        motion.x = Input.GetAxisRaw("Horizontal") * speed;
        motion.y = rb.velocity.y;
        
        restaMP = mousePosition - transform.position;
        restaMP.y = restaMP.y + .5f;
        if(mousePosition.x > transform.position.x)
        {
            restaMP.x = restaMP.x - .5f;
        }
        else
        {
            restaMP.x = restaMP.x + .5f;
        }
        

        if (mousePosition.x > transform.position.x && !facingRight)
        {
            CreateDust();
            facingRight = true;
            transform.Rotate(0, 180, 0);
        }
        
        if (mousePosition.x < transform.position.x && facingRight)
        {
            CreateDust();
            facingRight = false;
            transform.Rotate(0, 180, 0);
        }

        if (motion.x == 0)
        {
            audioSrc.Stop();
        }

        if (motion.x != 0 && grounded == true && !audioSrc.isPlaying)
        {
            audioSrc.Play();
        }

        //AIRS
        if ((motion.y < 0) && grounded == true)
        {
            audioSrc.Stop();
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.S) && pesa == true && grounded == false) //ground pound
        {
            animator.SetFloat("pesa", 1);
            motion.y = .0001F;
            rb.gravityScale = 10;
            pesa = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && djump == true && grounded == false) //double jump
        {
            SoundManagerScript.PlaySound("JUMP");
            animator.SetFloat("pesa", 0);
            dustLand.Play();
            motion.y = .0001F;
            rb.gravityScale = 1;
            rb.AddForce(jumpForce);
            djump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true) //jump
        {
            audioSrc.Stop();
            SoundManagerScript.PlaySound("JUMP");
            motion.y = .0001F;
            rb.gravityScale = 1;
            rb.AddForce(jumpForce);
            grounded = false;
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && grounded == false && motion.y > 0)
        {
            motion.y = motion.y/2;
        }
        
        rb.velocity = motion;

        //ANIMATION
        animator.SetFloat("speedy", motion.y);
        animator.SetFloat("speedx", motion.x);

    }

    //TOCAR SUELO
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            SoundManagerScript.PlaySound("LAND");
            animator.SetFloat("pesa", 0);
            dustLand.Play();
            grounded = true;
            djump = true;
            pesa = true;
            rb.gravityScale = 1;
        }
    }

    //PARTICULAS
    void CreateDust()
    {
        if (grounded == true)
        {
            dustDir.Play();
        }
    }
}

