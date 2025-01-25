using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool moving = false;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (moving)
            autoMove();
    }

    void autoMove()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    // trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bubble"))
        {
            other.GetComponent<Bubble>().trigger();
        }
    }
}
