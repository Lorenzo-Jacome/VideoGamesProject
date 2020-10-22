using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemBulletMov : MonoBehaviour
{
    float moveSpeed = 9f;
    Rigidbody2D rb;

    MotionRB target;
    Vector2 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindObjectOfType<MotionRB>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        moveDirection.y = moveDirection.y -.1f;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy (gameObject, 3f);
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals ("Player"))
        {
            Destroy (gameObject);
        }
    }
}
