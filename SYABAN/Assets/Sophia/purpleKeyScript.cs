using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class purpleKeyScript : MonoBehaviour
{
    public hudDATA hudData;
    private void OnTriggerStay2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Time.timeScale = 1f;
        KeyManager.Instance.purplekeyCount++;
        //KeyManager.Instance.greenkeyCount++;
        SceneManager.LoadScene("SophiaScene");
    }
}
}
