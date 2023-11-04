using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] public Transform character;
    [SerializeField] public float cameraHeight;
    public float followSpeed = 3f;

    // LateUpdate is called once per frame after thre last Update
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(character.position.x, cameraHeight, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
