using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BubbleType { Platform, Boom, Shield, Gravity }

public class Bubble : MonoBehaviour
{
    public BubbleType bubbleType;
    public float price;
    [SerializeField] SpriteRenderer spriteRenderer;

    public void init(BubbleType bubbleType)
    {
        this.bubbleType = bubbleType;
        switch (bubbleType)
        {
            case BubbleType.Platform:
                spriteRenderer.sprite = BubbleManager.Instance.bubbleData[0].sprite;
                break;
            case BubbleType.Boom:
                spriteRenderer.sprite = BubbleManager.Instance.bubbleData[1].sprite;
                break;
            case BubbleType.Shield:
                spriteRenderer.sprite = BubbleManager.Instance.bubbleData[2].sprite;
                break;
            case BubbleType.Gravity:
                spriteRenderer.sprite = BubbleManager.Instance.bubbleData[3].sprite;
                break;
        }
        price = BubbleManager.Instance.bubbleData[(int)bubbleType].price;
        gameObject.SetActive(true);
    }

    public void trigger()
    {
        switch (bubbleType)
        {
            case BubbleType.Platform:
                Debug.Log("Platform");
                break;
            case BubbleType.Boom:
                Debug.Log("Boom");
                break;
            case BubbleType.Shield:
                Debug.Log("Shield");
                break;
            case BubbleType.Gravity:
                Debug.Log("Gravity");
                break;
            // GameManager.Instance.player.moving = false;
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
