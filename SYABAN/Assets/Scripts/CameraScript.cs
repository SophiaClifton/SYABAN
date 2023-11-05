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
       if(KeyManager.Instance.startgame == true){}
       else{
            Vector3 newPos = new Vector3(character.position.x, cameraHeight, -10f);
            //transform.position = newPos;
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Round(transform.position.x * 100)/100, Mathf.Round(transform.position.y * 100)/100, Mathf.Round(transform.position.z * 100)/100);
       }
    }
}
