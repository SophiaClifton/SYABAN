using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float range;
    public Transform target;
    private float minDistance = 5.0f;
    private bool targetCollision = false;
    private float speed = 3f;
    private float thrust = 4f;
    public Animator animator;
    public int health = 100;
    public hudDATA hudData;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hudData.active)
        {
            if(health <=0)
            {
                Destroy(gameObject);
            }
            range = Vector2.Distance(transform.position, target.position);
            if(range < minDistance)
            {
                if (!targetCollision)
                {

                    //get position of the player
                    transform.LookAt(target.position);
                    if(target.position.x> gameObject.transform.position.x)
                    {
                        gameObject.transform.localScale = new Vector3(1f,1f,1f);
                    }
                    else if(target.position.x< gameObject.transform.position.x)
                    {
                        gameObject.transform.localScale = new Vector3(-1f,1f,1f);
                    }
                    else {}
                    //correct rotation
                    transform.Rotate(new Vector3(0,-90,0), Space.Self);
                    transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
                    animator.Play("Enemy_run");
                }
            }
            else{
                Invoke("FalseCollision", 0.25f);
                animator.Play("Enemy_Idle");
                }

            transform.rotation= Quaternion.identity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;

            targetCollision = true;

            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            
             if (right) GetComponent<Rigidbody2D>().AddForce(transform.right * thrust, ForceMode2D.Impulse); 
             if (left) GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust, ForceMode2D.Impulse); 
             Invoke("FalseCollision", 0.25f);
             animator.Play("Enemy_Idle");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            Vector3 contactPoint = collision.ClosestPoint(transform.position);
            Vector3 center = collision.bounds.center;

            targetCollision = true;

            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;

             if (right) GetComponent<Rigidbody2D>().AddForce(transform.right * thrust, ForceMode2D.Impulse); 
             if (left) GetComponent<Rigidbody2D>().AddForce(-transform.right * thrust, ForceMode2D.Impulse); 
             Invoke("FalseCollision", 0.25f);
             animator.Play("Enemy_Idle");
        }
    }

    void FalseCollision ()
    {
        targetCollision= false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero; 
        
    } 
    public void TakeDamage(int amount)
    { 
        health -= amount;
    }
}
