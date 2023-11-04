using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButtonScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public void pauseButtonClicked()
    {
        gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
