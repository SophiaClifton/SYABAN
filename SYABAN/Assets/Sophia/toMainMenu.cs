using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMainMenu : MonoBehaviour
{
    // Update is called once per frame
    public void returnMainMenu()
    {
        SceneManager.LoadScene("SophiaScene");
    } 
}
