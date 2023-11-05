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

    private bool isActive = false;

    public override void Interact() {
        linkedObstacle.Activate();
        StartCoroutine(wait(true));
    }

    public override void StopInteract() {
        linkedObstacle.Deactivate();
        StartCoroutine(waitMore());
        stopInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interact) {
            interact = false;
            Interact();
        }
        if (stopInteract) {
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
        yield return new WaitForSeconds(3);  
    }
}
