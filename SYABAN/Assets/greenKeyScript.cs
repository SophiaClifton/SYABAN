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
        hudData.level2complete =true;
        SceneManager.LoadScene("SophiaScene");
    }
}
}
