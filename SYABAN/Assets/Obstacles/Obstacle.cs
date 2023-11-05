using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Allow the players to pass.
    public virtual void Activate() {
    }

    // Block the players.
    public virtual void Deactivate() {
    }
}
