using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool moving = false;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool haveShield = false;

    [SerializeField] GameObject shield;

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

    public void getShield()
    {
        haveShield = true;
        shield.SetActive(true);
    }

    // trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bubble"))
        {
            other.GetComponent<Bubble>().trigger();
        }

        if (other.CompareTag("spike"))
        {
            if (haveShield)
            {
                haveShield = false;
                // hide shield
                shield.SetActive(false);
                return;
            }
            GameManager.Instance.gameOver();
        }
    }
}
