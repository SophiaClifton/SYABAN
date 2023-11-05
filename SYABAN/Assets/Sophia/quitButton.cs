using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : MonoBehaviour
{

    public void quitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    
}

