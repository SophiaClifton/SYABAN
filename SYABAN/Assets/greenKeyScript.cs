using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class greenKeyScript : MonoBehaviour
{
    public hudDATA hudData;
    private void OnTriggerStay2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Time.timeScale = 1f;
        KeyManager.Instance.greenkeyCount++;
        SceneManager.LoadScene("SophiaScene");
    }
}
}
