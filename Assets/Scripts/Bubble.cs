using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BubbleType { Basic, Boom, Gravity, Shield }

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
            case BubbleType.Basic:
                spriteRenderer.sprite = BubbleManager.Instance.bubbleData[0].sprite;
                break;
            case BubbleType.Boom:
                spriteRenderer.sprite = BubbleManager.Instance.bubbleData[1].sprite;
                break;
            case BubbleType.Gravity:
                spriteRenderer.sprite = BubbleManager.Instance.bubbleData[2].sprite;
                break;
            case BubbleType.Shield:
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
            case BubbleType.Basic:
                break;
            case BubbleType.Boom:
                GameManager.Instance.player.rb.velocity = new Vector2(GameManager.Instance.player.rb.velocity.x, 0);
                GameManager.Instance.player.rb.AddForce(Vector2.up * BubbleManager.Instance.boomForce * 
                    GameManager.Instance.player.rb.gravityScale, ForceMode2D.Impulse);
                Destroy(gameObject);
                break;
            case BubbleType.Gravity:
                GameManager.Instance.player.rb.gravityScale = -GameManager.Instance.player.rb.gravityScale;
                Destroy(gameObject);
                break;
            case BubbleType.Shield:
                GameManager.Instance.player.getShield();
                Destroy(gameObject);
                break;
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
