using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public int currentLvl = 0;
    public Transform spawnPt;
    public Player player;
    public Button startBtn;

    public void selectLvl(int idx)
    {
        currentLvl = idx;
        LevelManager.Instance.loadLvl(idx);
    }

    public void gameOver()
    {
        Debug.Log("Game Over");
        player.moving = false;
    }

    public void startlvl()
    {
        Debug.Log("Start Level");
        player.moving = true;
        startBtn.gameObject.SetActive(false);
        BuildingSystem.Instance.deselectBubble();
    }

    // debug
    [ContextMenu("fk")]
    public void loadLvl2()
    {
        selectLvl(2);
    }
}
