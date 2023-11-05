using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    GameObject triggeredInteractable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (triggeredInteractable != null) {
                triggeredInteractable.GetComponent<Interactable>().Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        Interactable temp = other.gameObject.GetComponent<Interactable>();
        if (temp != null) {
            triggeredInteractable = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject == triggeredInteractable) {
            triggeredInteractable = null;
        }
    }
}
