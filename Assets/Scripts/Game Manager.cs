using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int currentLvl = 0;
    [SerializeField] Transform spawnPt;
    [SerializeField] Player player;
    [SerializeField] Button startBtn;

    public void loadLvl()
    {
        Debug.Log("Load Level");
        player.moving = false;
        startBtn.gameObject.SetActive(true);
    }

    public void gameOver()
    {
        Debug.Log("Game Over");
        player.moving = false;
    }

    public void startlvl() {
        Debug.Log("Start Level");
        player.moving = true;
        startBtn.gameObject.SetActive(false);
    }
}
