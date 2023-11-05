using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseButton;
    public hudDATA hudData;
    public void startGame()
    {
        mainMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        hudData.active = true;
        hudData.startOfGame=false;
        KeyManager.Instance.startgame=false;
        

    }
}
