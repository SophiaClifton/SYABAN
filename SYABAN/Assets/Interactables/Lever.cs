using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Interact() {
        if (!activated) {
            linkedObstacle.Activate();
            activated = true;
        }
        else {
            linkedObstacle.Deactivate();
            activated = false;
        }
    }

    public override void StopInteract() {
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