using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    void Update()
    {
        autoMove();
    }

    void autoMove()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
}
