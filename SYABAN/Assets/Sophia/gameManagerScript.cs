using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public hudDATA hudData; 

    private void Start()
    {
        InitializeGame();
    }

    public void InitializeGame()
    {
        hudData.active = false;
        hudData.level1complete = false;
        hudData.level2complete = false;
    }
}
