using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Interact() {
        linkedObstacle.Activate();
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
}
