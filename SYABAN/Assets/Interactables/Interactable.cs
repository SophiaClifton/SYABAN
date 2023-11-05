using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField] protected Obstacle linkedObstacle;
    public bool interact;
    public bool stopInteract;
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
