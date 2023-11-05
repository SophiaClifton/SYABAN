using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public Transform firepoint;
    [SerializeField] public GameObject pinkBulletPrefab;
    public int maxHealth = 3;
    private int health;
    public string color = "pink";
    public GameObject particles;

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
