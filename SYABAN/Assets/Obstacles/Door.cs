using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Obstacle
{
    protected BoxCollider2D doorCollider;
    protected SpriteRenderer doorRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorRenderer = GetComponent<SpriteRenderer>();
    }

    // Allow the players to pass.
    public override void Activate() {
        Debug.Log("Activated");
        doorCollider.enabled = false;
        doorRenderer.enabled = false;
    }

    // Block the players.
    public override void Deactivate() {
        Debug.Log("Deactivated");
        doorCollider.enabled = true;
        doorRenderer.enabled = true;
    }
}
