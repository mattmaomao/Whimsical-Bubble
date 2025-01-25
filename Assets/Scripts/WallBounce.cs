using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] bool isLeft;

    // trigger
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("bubble"))
        {
            if (other.GetComponent<Bubble>().bubbleType == BubbleType.Basic)
                if ((isLeft && player.moveSpeed < 0) || (!isLeft && player.moveSpeed > 0))
                {
                    AudioManager.Instance.playSE(AudioManager.Instance.BOUNCE);
                    player.moveSpeed = -player.moveSpeed;
                }
        }

        if (other.CompareTag("wall"))
        {
            if ((isLeft && player.moveSpeed < 0) || (!isLeft && player.moveSpeed > 0))
            {
                AudioManager.Instance.playSE(AudioManager.Instance.BOUNCE);
                player.moveSpeed = -player.moveSpeed;
            }
        }
    }
}
