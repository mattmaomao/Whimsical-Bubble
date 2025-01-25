using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform turrent;
    [SerializeField] float flySpeed = 5f;
    public Vector2 direction;

    [SerializeField] Sprite arrowUp;
    [SerializeField] Sprite arrowDown;
    [SerializeField] Sprite arrowLeft;
    [SerializeField] Sprite arrowRight;

    void Update()
    {
        transform.Translate(direction * flySpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, turrent.position) > 30f)
            Destroy(gameObject);
    }

    public void init(Vector2 direction, Transform turrent)
    {
        this.turrent = turrent;
        this.direction = direction;
        if (direction == Vector2.up)
            GetComponent<SpriteRenderer>().sprite = arrowUp;
        else if (direction == Vector2.down)
            GetComponent<SpriteRenderer>().sprite = arrowDown;
        else if (direction == Vector2.left)
            GetComponent<SpriteRenderer>().sprite = arrowLeft;
        else if (direction == Vector2.right)
            GetComponent<SpriteRenderer>().sprite = arrowRight;
    }
}
