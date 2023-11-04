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
    public int time = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log(collision);
        button = collision.GetComponent<InteractableButton>();
Debug.Log(button);
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
            Debug.Log("here2");
            StartCoroutine(interact());}
            
        }

        Destroy(gameObject);
    }

    IEnumerator interact()
    {
        Debug.Log("here3");
        button.interact = true;
        yield return new WaitForSeconds(time);
        button.interact = false;    
    }
   
}
