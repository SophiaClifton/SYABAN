using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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

        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(20);
        }
    }
}
