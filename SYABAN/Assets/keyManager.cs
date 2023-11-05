using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance;
    public int purplekeyCount = 0;
    public int greenkeyCount = 0;
    public bool startgame =true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add methods to increase and decrease the key count as needed
}
