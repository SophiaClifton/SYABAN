using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainMenu : MonoBehaviour
{
    public hudDATA hudData;
    // Update is called once per frame
    public void returnMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SophiaScene");
    } 
}
