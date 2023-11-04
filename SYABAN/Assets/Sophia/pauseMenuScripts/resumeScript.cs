using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
}
