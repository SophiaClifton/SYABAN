using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPowers : MonoBehaviour
{

    [SerializeField] public Transform firepoint;
    [SerializeField] public GameObject pinkBulletPrefab;
    [SerializeField] public GameObject yellowBulletPrefab;
    [SerializeField] public GameObject greenBulletPrefab;

    [SerializeField] public Sprite pinkSprite;
    [SerializeField] public Sprite yellowSprite;
    [SerializeField] public Sprite greenSprite;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    enum bulletColor
    {
        pink,
        yellow,
        green
    }

    private bulletColor currentBullet;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) == true )
        {
            currentBullet = bulletColor.pink;
            spriteRenderer.sprite = pinkSprite;

        } else if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            currentBullet = bulletColor.yellow;
            spriteRenderer.sprite = yellowSprite;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) == true)
        {
            currentBullet = bulletColor.green;
            spriteRenderer.sprite = greenSprite;                
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

       
    }
    
    
 void Attack()
        {

        switch (currentBullet)
        {
            case bulletColor.pink:
                Instantiate(pinkBulletPrefab, firepoint.position, firepoint.rotation);
                break;
            case bulletColor.yellow:
                Instantiate(yellowBulletPrefab, firepoint.position, firepoint.rotation);
                break;
            case bulletColor.green:
                Instantiate(greenBulletPrefab, firepoint.position, firepoint.rotation);
                break;
            default:
                break;
        }

        }

}
