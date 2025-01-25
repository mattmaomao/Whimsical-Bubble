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
    public bool gameRunning = false;
    public int i = 0;

    [Header("Scene")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject levelselect;
    [SerializeField] GameObject winningPanel;

    [Header("Tutorial")]
    [SerializeField] GameObject tutorialPanel;

    void Start()
    {
        mainMenu.SetActive(true);
        game.SetActive(false);
        levelselect.SetActive(false);
        gameoverPanel.SetActive(false);
        winningPanel.SetActive(false);
        PlayerPrefs.SetInt("tutorial", 0);
    }

    void Update()
    {
        if (mainMenu.activeSelf)
            if (Input.GetKey(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                if (PlayerPrefs.GetInt("tutorial") == 0) {
                    tutorialPanel.SetActive(true);
                    PlayerPrefs.SetInt("tutorial", 1);
                }
                mainMenu.SetActive(false); 
                game.SetActive(false);
                levelselect.SetActive(true);
                gameoverPanel.SetActive(false);
                winningPanel.SetActive(false);
                if (AudioManager.Instance.returnMusicClip() != AudioManager.Instance.TITLE){
                AudioManager.Instance.playMusic(AudioManager.Instance.TITLE);
                }
            }

        if (gameoverPanel.activeSelf)
            if (Input.GetKey(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {   
                
                gameoverPanel.SetActive(false);
                
                
                mainMenu.SetActive(false);
                game.SetActive(false);
                //reset lvl using building system's funciton
               
                levelselect.SetActive(true);
                winningPanel.SetActive(false);
                    if (AudioManager.Instance.returnMusicClip() != AudioManager.Instance.TITLE){
                  AudioManager.Instance.playMusic(AudioManager.Instance.TITLE);
                    }
                   BuildingSystem.Instance.resetBuilding();
     
            }

            if (winningPanel.activeSelf)
            if (Input.GetKey(KeyCode.Return))
            {
                
                gameoverPanel.SetActive(false);
                mainMenu.SetActive(false);
                game.SetActive(false);
                //reset lvl using building system's funciton
                BuildingSystem.Instance.resetBuilding();
                levelselect.SetActive(true);
                if (AudioManager.Instance.returnMusicClip() != AudioManager.Instance.TITLE){
                AudioManager.Instance.playMusic(AudioManager.Instance.TITLE);
                }
              
                winningPanel.SetActive(false);
            }
    }
    public void selectLvl(int idx)
    {
        currentLvl = idx;
        LevelManager.Instance.loadLvl(idx);

    }

    public void completeLvl() {
        // todo
        Debug.Log("Level Complete");
        winningPanel.SetActive(true);
        gameoverPanel.SetActive(false);
        mainMenu.SetActive(false);
        game.SetActive(false);
        levelselect.SetActive(false);

    }

    public void gameOver()
    {
        Debug.Log("Game Over");
        AudioManager.Instance.playMusic(AudioManager.Instance.DEATH);
        gameRunning = false;
        gameoverPanel.SetActive(true);
        winningPanel.SetActive(false);
        mainMenu.SetActive(false);
        game.SetActive(false);
        levelselect.SetActive(false);

    }

    public void startlvl()
    {
        AudioManager.Instance.playMusic(AudioManager.Instance.PLAY);
        Debug.Log("Start Level");
        gameRunning = true;
        player.startMovement();
        startBtn.gameObject.SetActive(false);
        BuildingSystem.Instance.deselectBubble();
    }

    public void closeTutorial()
    {
        tutorialPanel.SetActive(false);
    }

    // debug
    [ContextMenu("fk")]
    public void loadLvl2()
    {
        selectLvl(2);
    }
}
