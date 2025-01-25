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

    [Header("Scene")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject levelselect;
    




    void Start()
    {
        // mainMenu.SetActive(true);
        // game.SetActive(false);
        // levelselect.SetActive(false);
        // gameoverPanel.SetActive(false);
        AudioManager.Instance.playMusic(AudioManager.Instance.TITLE);

    }

    void Update()
    {
        if (mainMenu.activeSelf)
            if (Input.GetKey(KeyCode.Return))
            {
                mainMenu.SetActive(false);
                game.SetActive(false);
                levelselect.SetActive(true);
            }
    }
    public void selectLvl(int idx)
    {
        currentLvl = idx;
        LevelManager.Instance.loadLvl(idx);
    }

    public void gameOver()
    {
        Debug.Log("Game Over");
        AudioManager.Instance.playMusic(AudioManager.Instance.DEATH);
        player.moving = false;
        gameoverPanel.SetActive(true);
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
