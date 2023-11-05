using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "hudDATA", menuName = "hudData")]
public class hudDATA : ScriptableObject
{
    public bool active = false;
    public bool level1complete = false;
    public bool level2complete = false;
    public bool startOfGame =true;

    public void Start ()
    {
        
        active = false;
        
    }
}
