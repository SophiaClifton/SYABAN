using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Image[] hearts;
    public Sprite heart;
    public int Respawn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<maxHealth; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true;
            }
            else { 
                hearts[i].enabled = false; 
            }
        }
    }

    void loseHealth()
    {
        currentHealth = currentHealth - 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy"){
            loseHealth();
            if (currentHealth == 0)
            {
                SceneManager.LoadScene(Respawn);
            }
        }
        
    }
}
