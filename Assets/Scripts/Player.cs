using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool moving = false;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool haveShield = false;

    [SerializeField] GameObject shield;
    GameObject cotactingObj;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.Instance.gameRunning)
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
            Debug.Log(other.gameObject);
            Debug.Log(other.gameObject == cotactingObj);
            if (other.gameObject == cotactingObj)
                return;

            AudioManager.Instance.playSE(AudioManager.Instance.SPIKE);
            if (haveShield)
            {
                Debug.Log("Shield");
                cotactingObj = other.gameObject;
                haveShield = false;
                // hide shield
                shield.SetActive(false);
                return;
            }
            else
            {
                GameManager.Instance.gameOver();
            }
        }

        // if (other.CompareTag("arrow"))
        // {
        //     AudioManager.Instance.playSE(AudioManager.Instance.ARROW);
        //     if (haveShield)
        //     {
        //         haveShield = false;
        //         // hide shield
        //         shield.SetActive(false);
        //         return;
        //     }
        //     GameManager.Instance.gameOver();
        // }

        if (other.CompareTag("end pt"))
        {
            GameManager.Instance.completeLvl();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("spike") && other.gameObject == cotactingObj)
        {
            cotactingObj = null;
        }
    }
}
