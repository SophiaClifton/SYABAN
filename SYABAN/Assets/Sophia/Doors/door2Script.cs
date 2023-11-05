using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door2Script : MonoBehaviour
{
    public GameObject interactE;
    private bool isInteracting = false;

private void OnTriggerStay2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        isInteracting = true;
        interactE.SetActive(true);
    }
}

private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        isInteracting = false;
        interactE.SetActive(false);
    }
}

private void Update()
{
    if (isInteracting && Input.GetKeyDown(KeyCode.E))
    {
        Debug.Log("levelpurple");
        SceneManager.LoadScene("LevelPurple");
    }
}

}
