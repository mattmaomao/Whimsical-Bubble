using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    [SerializeField] Player player;
    
    // trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {   
            player.moveSpeed = -player.moveSpeed;
        }
    }
}
