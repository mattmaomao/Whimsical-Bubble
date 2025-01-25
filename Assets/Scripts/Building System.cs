using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{
    [SerializeField] BubbleManager bubbleManager;

    [SerializeField] float currency = 1000f;
    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] int selectingBubble = -1;
    [SerializeField] GameObject cursorBubbleImg;
    [SerializeField] Transform bubbleContainer;

    void Start()
    {
    }

    void Update()
    {
        if (selectingBubble != -1)
        {
            // show bubble on cursor
            cursorBubbleImg.SetActive(true);
            cursorBubbleImg.transform.position = Input.mousePosition;

            // place bubble
            if (Input.GetMouseButtonDown(0))
            {
                if (currency >= bubbleManager.bubbleData[selectingBubble].price)
                {
                    // snap posisiton to grid
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.x = Mathf.Round(mousePos.x);
                    mousePos.y = Mathf.Round(mousePos.y);
                    mousePos.z = 0;

                    // todo: check if the position is valid

                    // Instantiate bubble
                    GameObject temp = Instantiate(bubbleManager.bubbleData[selectingBubble].prefab, mousePos, Quaternion.identity);
                    temp.transform.SetParent(bubbleContainer);
                    Bubble bubble = temp.GetComponent<Bubble>();
                    bubble.init((BubbleType) selectingBubble);


                    // Update currency
                    currency -= bubbleManager.bubbleData[selectingBubble].price;
                    currencyText.text = currency.ToString();
                }
            }

            // cancel placing bubble
            if (Input.GetMouseButtonDown(1))
            {
                deselectBubble();
            }
        }
    }

    public void resetBuilding(float currency = 100) {
        this.currency = currency;
        currencyText.text = currency.ToString();
        foreach (Transform child in bubbleContainer) {
            Destroy(child.gameObject);
        }
    }

    #region btns
    public void selectBubble(int idx)
    {
        selectingBubble = idx;
        cursorBubbleImg.GetComponent<Image>().sprite = bubbleManager.bubbleData[idx].sprite;
        cursorBubbleImg.SetActive(true);
    }
    public void deselectBubble()
    {
        selectingBubble = -1;
        cursorBubbleImg.SetActive(false);
    }
    #endregion
}
