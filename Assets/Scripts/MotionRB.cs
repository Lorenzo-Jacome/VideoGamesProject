using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionRB : MonoBehaviour
{
    //Variables animation
    public ParticleSystem dustDir;
    public ParticleSystem dustLand;
    public Animator animator;
    bool pesa;

    //Variables audio
    AudioSource audioSrc;

    //Variables movement
    public float speed;
    public Vector3 jumpForce;
    Vector3 motion;
    public Vector3 mousePosition;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public bool grounded;
    public bool walled;
    bool djump;
    bool facingRight = true;

    //Variables shooting
    public Camera cam;
    public Vector3 restaMP;
    public Transform FireSpawn;

    //Variables for stamina:
    public int maxStamina;
    public int currentStamina;
    public Slider staminaBar;
    bool counting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        grounded = false;
        walled = false;
        audioSrc = GetComponent<AudioSource>();

        //Start stamina
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = currentStamina;
    }

    void StaminaSystem()
    {
            currentStamina -= 1;
            staminaBar.value = currentStamina;
    }

    // Update is called once per frame
    void Update()
    {
        //HORIZONTALS
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        motion.x = Input.GetAxisRaw("Horizontal") * speed;
        motion.y = rb.velocity.y;
        
        restaMP = mousePosition - FireSpawn.position;
        
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
            walled = false;
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

        if (Input.GetKeyDown(KeyCode.Space) && djump == true && grounded == false && currentStamina > 0) //double jump
        {
            SoundManagerScript.PlaySound("JUMP");
            animator.SetFloat("pesa", 0);
            dustLand.Play();
            motion.y = .0001F;
            rb.gravityScale = 1;
            rb.AddForce(jumpForce);
            djump = false;
            if (walled == true)
            {
                djump = true;
                walled = false;
            }

            StaminaSystem();
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true && currentStamina > 0){ //jump
            audioSrc.Stop();
            SoundManagerScript.PlaySound("JUMP");
            motion.y = .0001F;
            rb.gravityScale = 1;
            rb.AddForce(jumpForce);
            grounded = false;

            StaminaSystem();
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && grounded == false && motion.y > 0)
        {
            motion.y = motion.y/2;
        }
        
        rb.velocity = motion;

        //ANIMATION
        animator.SetFloat("speedx", 0);
        if (walled == false)
        {
            animator.SetFloat("speedx", motion.x);
        }
        animator.SetFloat("speedy", motion.y);

        //STAMINA REGEN
        staminaBar.value = currentStamina;
        if (currentStamina < maxStamina && counting == false)
        {
            //gameObject.GetComponent<Health>().HealthRegen(1);             HEALTH ADD TEST
            counting = true;
            StartCoroutine(StamRegen());
        }
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

        if (col.gameObject.tag == "Walls")
        {

            walled = true;

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

    //STAMINA TIMER
    public IEnumerator StamRegen()
    {
        yield return new WaitForSeconds(2f);
        if (currentStamina < maxStamina)
        {
            currentStamina += 1;
        }
        counting = false;
    }
}

