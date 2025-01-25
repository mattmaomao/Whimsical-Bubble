using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{
    public static BubbleManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField] public List<BubbleData> bubbleData;
    [SerializeField] public List<GameObject> bubbleBtns;

    void Start()
    {
        for (int i = 0; i < bubbleData.Count; i++)
        {
            bubbleBtns[i].GetComponent<Image>().sprite = bubbleData[i].sprite;
            bubbleBtns[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = bubbleData[i].price.ToString();
        }
    }
}


[Serializable]
public struct BubbleData
{
    public string name;
    public Sprite sprite;
    public float price;
    public GameObject prefab;
}