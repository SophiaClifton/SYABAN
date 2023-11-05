using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = -20f;
    public Rigidbody2D rb;
    private EnemyHealth enemy;
    private InteractableButton button;
    public GameObject particles;
    public int time = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
         
         if(collision.gameObject.name == "Button"){
            Debug.Log("here1");
            if(!button.interact){
                button.interact = true;
            }
        }
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log(collision);
        button = collision.GetComponent<InteractableButton>();
        Debug.Log("Button " + button);
        if(enemy != null)
        {
            //pink beats yellow
            //yellow beats green
            //green beats pink
            enemy.TakeDamage();
        }
         
        if(button != null){
            Debug.Log("here1");
            if(!button.interact){
                button.interact = true;
            }
        }

        if(collision.GetComponent<Shooting>() == null){
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("playerCollision");
        }

        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Debug.Log("playerCollision");
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(20);
        }
    }
   
}
