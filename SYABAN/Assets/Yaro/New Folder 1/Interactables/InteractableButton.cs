using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableButton : Interactable
{
    public int waitTime = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    private bool isWaiting = false;
    private bool isActive = false;

    public override void Interact() {
        GetComponent<SpriteRenderer>().sprite = activeSprite;
        linkedObstacle.Activate();
        StartCoroutine(wait(true));
    }

    public override void StopInteract() {
        GetComponent<SpriteRenderer>().sprite = inactiveSprite;
        linkedObstacle.Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact) {
            interact = false;
            StopAllCoroutines();
            Interact();
        }
        if (stopInteract) {
            stopInteract = false;
            StopInteract();
        }
    }

    IEnumerator wait(bool x)
    {
        yield return new WaitForSeconds(waitTime);  
        stopInteract = true;
    }

    IEnumerator waitMore()
    {
        isWaiting = true;
        yield return new WaitForSeconds(2);  
        isWaiting = false;
        GetComponent<SpriteRenderer>().sprite = inactiveSprite;
    }
}
