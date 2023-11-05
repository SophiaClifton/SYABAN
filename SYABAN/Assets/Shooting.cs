using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public Transform firepoint;
    [SerializeField] public GameObject BulletPrefab;
    [SerializeField] public GameObject player;
    bool coroutineStarted = false;
     private bool targetCollision = false;
    private float speed = 3f;
    private float thrust = 4f;
    public Animator animator;
    public int health = 100;
    private float range;
    private float minDistance = 5.0f;
    public Transform target;
    public GameObject particles;
    public int waitBetweenShoot = 1;
    // Start is called before the first frame update
    void Start()
    {
           
          
    }
    
      IEnumerator ExampleCoroutine()
    {   coroutineStarted = true;
        animator.SetBool("isShooting",true);
        Instantiate(BulletPrefab, firepoint.position, firepoint.rotation);
        yield return new WaitForSeconds(1);
        animator.SetBool("isShooting",false);
        yield return new WaitForSeconds(waitBetweenShoot);
        coroutineStarted = false;
    }
    // Update is called once per frame
    void Update()
    {

         if(health <= 0)
        {
            Destroy(gameObject);
        }

        range = Vector2.Distance(transform.position, target.position);
        if(range < minDistance)
        {
                //get position of the player
        
                if(target.position.x < gameObject.transform.position.x)
                {
                    if(gameObject.transform.localScale != new Vector3(1f,1f,1f)){
                       Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        firepoint.transform.Rotate(0, -180, 0);
                    }
                }
                else if(target.position.x > gameObject.transform.position.x)
                {
                    if(gameObject.transform.localScale != new Vector3(-1f,1f,1f)){
                        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        firepoint.transform.Rotate(0, -180, 0);
                    }
                }
                else {}
                
                if(!coroutineStarted)
                 StartCoroutine(ExampleCoroutine());
            }

          transform.rotation= Quaternion.identity;
        }

        public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

    }

