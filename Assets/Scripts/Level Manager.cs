using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField] List<GameObject> levels;
    [SerializeField] GameObject game;   
    [SerializeField] GameObject winningPanel;
    [SerializeField] GameObject losepanel;
    [SerializeField] GameObject levelselect;

    public void loadLvl(int idx)
    {
        Debug.Log("Load Level");
        foreach (GameObject level in levels)
            level.SetActive(false);
        levels[idx].SetActive(true);
        game.SetActive(true);
        winningPanel.SetActive(false);
        losepanel.SetActive(false);
        levelselect.SetActive(false);
        
        GameManager.Instance.spawnPt = levels[idx].transform.Find("spawn pt");
        GameManager.Instance.gameRunning = false;
        GameManager.Instance.player.transform.position = GameManager.Instance.spawnPt.position;
        GameManager.Instance.player.gameObject.SetActive(true);
        GameManager.Instance.startBtn.gameObject.SetActive(true);

        AudioManager.Instance.playMusic(AudioManager.Instance.PLAY);
    }
}
