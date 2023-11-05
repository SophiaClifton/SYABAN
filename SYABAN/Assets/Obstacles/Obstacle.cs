using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] protected AudioClip activateSound;
    [SerializeField] protected AudioClip deactivateSound;

    protected AudioSource audioSource;


    // Allow the players to pass.
    public virtual void Activate() {
    }

    // Block the players.
    public virtual void Deactivate() {
    }
}
