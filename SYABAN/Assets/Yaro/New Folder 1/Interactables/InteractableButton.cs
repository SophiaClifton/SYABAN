using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    public int waitTime = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Interact() {
        linkedObstacle.Activate();
        StartCoroutine(wait(true));
    }

    public override void StopInteract() {
        linkedObstacle.Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact) {
            interact = false;
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
        StopInteract();
    }
}
