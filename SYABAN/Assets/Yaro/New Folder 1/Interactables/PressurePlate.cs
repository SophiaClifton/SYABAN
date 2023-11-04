using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Interact() {
        
    }

    public override void StopInteract() {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerController>() != null) {
            linkedObstacle.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<PlayerController>() != null) {
            linkedObstacle.Deactivate();
        }
    }
}