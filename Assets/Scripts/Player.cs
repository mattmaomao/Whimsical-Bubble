using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool haveShield = false;

    [SerializeField] GameObject shield;
    GameObject cotactingObj;

    [Header("Animation")]
    [SerializeField] Animator animator;
    [SerializeField] bool isFacingLeft = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (GameManager.Instance.gameRunning)
            autoMove();

        if (Mathf.Abs(rb.velocity.x) >= 1)
            animator.SetBool("moving", true);
        else
            animator.SetBool("moving", false);

        if (Mathf.Abs(rb.velocity.y) >= 1)
            animator.SetBool("jumping", true);
        else
            animator.SetBool("jumping", false);


        if (isFacingLeft)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);
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
        Debug.Log(other.tag);
        
        if (other.CompareTag("bubble"))
        {
            other.GetComponent<Bubble>().trigger();
        }

        if (other.CompareTag("spike") || other.CompareTag("arrow"))
        {
            if (other.gameObject == cotactingObj)
                return;

            if (other.CompareTag("arrow"))
                AudioManager.Instance.playSE(AudioManager.Instance.ARROW);
            else if (other.CompareTag("spike"))
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
                GameManager.Instance.gameRunning = false;
                animator.SetBool("getHit", true);
                // wait 1 sec
                StartCoroutine(waitGameOver());
            }
        }

        if (other.CompareTag("end pt"))
        {
            GameManager.Instance.gameRunning = false;
            animator.SetBool("winning", true);
            // wait 1 sec
            StartCoroutine(waitWin());
        }
    }

    IEnumerator waitGameOver()
    {
        stopMovement();
        yield return new WaitForSeconds(1);
        GameManager.Instance.gameOver();
        animator.SetBool("getHit", false);
    }

    IEnumerator waitWin()
    {
        stopMovement();
        yield return new WaitForSeconds(1);
        GameManager.Instance.completeLvl();
        animator.SetBool("winning", false);
    }

    public void startMovement()
    {
        rb.gravityScale = 1;
    }

    void stopMovement()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("spike") && other.gameObject == cotactingObj)
        {
            cotactingObj = null;
        }
    }
}
