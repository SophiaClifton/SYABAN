using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Transform character;
    public float followSpeed = 3f;

    // LateUpdate is called once per frame after thre last Update
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(character.position.x, character.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
