using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "hudDATA", menuName = "hudData")]
public class hudDATA : ScriptableObject
{
    public bool active = false;

    public void Start ()
    {
        active = false;
    }
}
