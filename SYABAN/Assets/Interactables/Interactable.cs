using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Interactable : MonoBehaviour
{
    [SerializeField] protected Obstacle linkedObstacle;
    [SerializeField] protected Sprite inactiveSprite;
    [SerializeField] protected Sprite activeSprite;
    [SerializeField] protected AudioClip activateSound;
    [SerializeField] protected AudioClip deactivateSound;
    public bool interact;
    public bool stopInteract;
    protected SpriteRenderer spriteRenderer;
    protected AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void Interact() {

    }

    public virtual void StopInteract() {
        
    }
}
