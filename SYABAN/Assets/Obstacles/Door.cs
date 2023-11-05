using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Obstacle
{
    [SerializeField] float activeXIncrease;
    [SerializeField] float activeYIncrease;
    [SerializeField] float openTime = 1;
    protected BoxCollider2D doorCollider;
    protected SpriteRenderer doorRenderer;

    Vector3 velocity = Vector3.zero;
    Vector3 inactivePos;
    Vector3 activePos;

    bool active = false;
    bool reachedDestination = true;
    
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
        doorRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        inactivePos = transform.position;
        activePos = new Vector3(transform.position.x + activeXIncrease, transform.position.y + activeYIncrease, transform.position.z);
    }

    private void Update() {
        if (!reachedDestination) {
            if (active) {
                transform.position = Vector3.SmoothDamp(transform.position, activePos, ref velocity, openTime);
                if (Vector3.Distance(transform.position, activePos) <= 0.05) {
                    transform.position = activePos;
                    reachedDestination = true;
                }
            } else {
                transform.position = Vector3.SmoothDamp(transform.position, inactivePos, ref velocity, openTime);
                if (Vector3.Distance(transform.position, inactivePos) <= 0.05) {
                    transform.position = inactivePos;
                    reachedDestination = true;
                }
            }
        }
    }

    // Allow the players to pass.
    public override void Activate() {
        Debug.Log("Activated");

        active = true;
        audioSource.Stop();
        if (transform.position != activePos) {
            audioSource.PlayOneShot(activateSound);
            reachedDestination = false;
        }
        
    }

    // Block the players.
    public override void Deactivate() {
        Debug.Log("Deactivated");

        active = false;
        audioSource.Stop();
        if (transform.position != inactivePos) {
            audioSource.PlayOneShot(deactivateSound);
            reachedDestination = false;
        }
    }
}
