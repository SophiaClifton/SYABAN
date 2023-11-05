using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYaro : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        InteractableButton button = collision.GetComponent<InteractableButton>();
        if(button != null){
            if(!button.interact){
                button.interact = true;
            }
        }
        if(collision.gameObject.CompareTag("Turret"))
        {
            Destroy(gameObject);
            Debug.Log("turretCollision");
        }
       
    }
}
