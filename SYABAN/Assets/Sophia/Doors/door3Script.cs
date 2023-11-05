using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door3Script : MonoBehaviour
{
    public GameObject interactE;
    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            interactE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                SceneManager.LoadScene("Door1Scene");
            }
        }
    }

    private void  OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            interactE.SetActive(false);
        }
    }
}
