using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int coins;
    public int lives;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            coins = 0;
            lives = 5;
        }

    }
    private void Update()
    {
        if (lives <= 0)
        {
            GuiManager.instance.showGameover();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().stopplayer();
        }
    }
}
