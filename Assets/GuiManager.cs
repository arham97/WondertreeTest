using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuiManager : MonoBehaviour
{

    public Text coins;
    public Text lives;

    public static GuiManager instance { get; private set; }
    public GameObject gameoverscreen;
    public GameObject winningScreen;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void showGameover()
    {
        gameoverscreen.SetActive(true);
    }

    public void showWinning()
    {
        winningScreen.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().stopplayer();

    }
    void Update()
    {
        coins.text = "x " + GameManager.instance.coins.ToString();      
        lives.text = "x " + GameManager.instance.lives.ToString();

    }
}
