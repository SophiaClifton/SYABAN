using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField] protected Obstacle linkedObstacle;
    [SerializeField] protected Sprite inactiveSprite;
    [SerializeField] protected Sprite activeSprite;
    public bool interact;
    public bool stopInteract;
    protected SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void Interact() {

    }

    public virtual void StopInteract() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interact) {
            interact = false;
            Interact();
        }
        if (stopInteract) {
            interact = false;
            StopInteract();
        }
    }
}
