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
    int keys = KeyManager.Instance.keyCount;

private void OnTriggerStay2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if(keys==2)
        {
            isInteracting = true;
            interactE.SetActive(true);
        }
        else if(keys==1)
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
    if (isInteracting && Input.GetKeyDown(KeyCode.E) && hudData.level1complete && hudData.level2complete)
    {
        Debug.Log("levelpurple");
        SceneManager.LoadScene("LevelPurple");
    }
}

}
