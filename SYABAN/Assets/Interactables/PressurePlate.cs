using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Interactable
{
    // Number of valid gameobjects triggering the pressure plate.
    public float triggerCount = 0;

    public override void Interact() {
        
    }

    public override void StopInteract() {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Box>() != null || other.GetComponent<PlayerScript>() != null) {
            triggerCount ++;
        }
        // Activate the linked obstacle on the first trigger.
        if (triggerCount == 1) {
            spriteRenderer.sprite = activeSprite;
            audioSource.Stop();
            audioSource.PlayOneShot(activateSound);
            linkedObstacle.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<Box>() != null || other.GetComponent<PlayerScript>() != null) {
            triggerCount --;
        }
        // If nothing is triggering the pressure plate, deactive the linked obstacle.
        if (triggerCount == 0) {
            spriteRenderer.sprite = inactiveSprite;
            audioSource.Stop();
            audioSource.PlayOneShot(deactivateSound);
            linkedObstacle.Deactivate();
        }
    }
}