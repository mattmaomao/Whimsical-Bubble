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

    public void loadLvl(int idx)
    {
        Debug.Log("Load Level");
        foreach (GameObject level in levels)
            level.SetActive(false);
        levels[idx].SetActive(true);
        
        GameManager.Instance.spawnPt = levels[idx].transform.Find("spawn pt");
        GameManager.Instance.gameRunning = false;
        GameManager.Instance.player.transform.position = GameManager.Instance.spawnPt.position;

        GameManager.Instance.startBtn.gameObject.SetActive(true);

        AudioManager.Instance.playMusic(AudioManager.Instance.PLAY);
    }
}
