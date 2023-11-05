using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door3Script : MonoBehaviour
{
    public GameObject interactE;
    public GameObject obj02;
    public GameObject obj12;
    private bool isInteracting = false;
    public hudDATA hudData;
    int purplekeys = KeyManager.Instance.purplekeyCount;
    int greenkeys = KeyManager.Instance.greenkeyCount;

private void OnTriggerStay2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if(purplekeys>=1 &&greenkeys>=1)
        {
            isInteracting = true;
            interactE.SetActive(true);
        }
        else if(purplekeys>=1 || greenkeys>=1)
        {
            obj12.SetActive(true);
        }
        else
        {
            obj02.SetActive(true);
        }
        
    }
}

private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        isInteracting = false;
        interactE.SetActive(false);
        obj12.SetActive(false);
        obj02.SetActive(false);
    }
}

private void Update()
{
    if (isInteracting && Input.GetKeyDown(KeyCode.E) && purplekeys>=1 &&greenkeys>=1)
    {
        SceneManager.LoadScene("EndingScene");
    }
}

}
