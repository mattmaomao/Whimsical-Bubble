using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BubbleType { Platform, Boom, Shield, Gravity }

public class Bubble : MonoBehaviour
{
    BubbleManager bubbleManager;
    public BubbleType bubbleType;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start()
    {
        bubbleManager = GameObject.Find("BubbleManager").GetComponent<BubbleManager>();
    }

    public void init(BubbleType bubbleType)
    {
        this.bubbleType = bubbleType;
        switch (bubbleType)
        {
            case BubbleType.Platform:
                spriteRenderer.sprite = bubbleManager.bubbleData[0].sprite;
                break;
            case BubbleType.Boom:
                spriteRenderer.sprite = bubbleManager.bubbleData[0].sprite;
                break;
            case BubbleType.Shield:
                spriteRenderer.sprite = bubbleManager.bubbleData[0].sprite;
                break;
            case BubbleType.Gravity:
                spriteRenderer.sprite = bubbleManager.bubbleData[0].sprite;
                break;
        }
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
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
