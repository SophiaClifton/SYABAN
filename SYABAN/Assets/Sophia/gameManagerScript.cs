using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public hudDATA hudData; 
    public GameObject mainMenu;

    private void Start()
    {
        InitializeGame();
        if(hudData.startOfGame)
        {
            mainMenu.SetActive(true);
        }
        
    }

    public void InitializeGame()
    {
        hudData.active = false;
        hudData.level1complete = false;
        hudData.level2complete = false;
    }
    public void Update ()
    {
        if(!hudData.startOfGame)
        {
            Time.timeScale = 1f;
        }
    }
}
