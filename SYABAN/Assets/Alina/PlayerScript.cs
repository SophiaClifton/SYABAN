using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    
    public Image HP; 
    public float HPWidth;
    public Image staminaIMG; 
    public float staminaWidth;
    public hudDATA hudData;
    [SerializeField] private float health;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private LayerMask blockingLayer;
    [SerializeField] private Transform groundCheck;
    
    [SerializeField] public Transform firepoint;
    [SerializeField] public bool isShooting;
    public bool HasStamina = true;
    public GameObject bullet;
    
    [SerializeField] private float stamina;
    
    private float horizontal;
    private bool isFacingRight = true;
    public Animator animator;
    private bool hasStamina = true;//use for determining if player can shoot /hit

    public bool isWalking;
    public bool IsWalking { get { return isWalking; } }

    // Start is called before the first frame update
    void Start()
    {
        HPWidth = HP.rectTransform.rect.width;
        staminaWidth = staminaIMG.rectTransform.rect.width;
        StartCoroutine(RegainStaminaOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(hudData.active)
            {
            horizontal = Input.GetAxisRaw("Horizontal");
            Flip();
            if (Input.GetButtonDown("Jump")&& IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            if (Input.GetButtonDown("Fire1") && HasStamina)
            {
                AttackPewPew();
            }
            if (Input.GetButtonUp("Fire1") && HasStamina)
            {
                animator.SetBool("IsShooting", false);
                isShooting = false;
            }
            if (Input.GetButtonDown("Fire2") && HasStamina)
            {
                AttackSlash();
            }
            if (Input.GetButtonUp("Fire2"))
            {
                animator.SetBool("IsSlashing", false);
            }
        }

        if (IsGrounded() && math.abs(rb.velocity.x) > 0.05f) {
            isWalking = true;
        } else {
            isWalking = false;
        }
    }

    void FixedUpdate()
    {
         rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //movement left and right
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, blockingLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            firepoint.transform.Rotate(0, -180, 0);
        }
    }

    public void TakeDamage(int amount)
    {
        if(health>0)
        {
            health -= amount;
            HPWidth -= amount;
            Vector2 temp = new Vector2(HPWidth, HP.rectTransform.rect.height);
            HP.rectTransform.sizeDelta = temp;
        }
    }

    public void AttackPewPew()
    {
        if(hasStamina){
            animator.SetBool("IsShooting", true); 
            isShooting = true;
            Debug.Log("Attack point reached");
            Instantiate(bullet, firepoint.position,firepoint.rotation);
            loseStamina();
        }
    }

    public void AttackSlash()
    {
        if(hasStamina)
        {
            animator.SetBool("IsSlashing", true);
            loseStamina();
        }
    }
     
    public void loseStamina()
    {
        
        if(stamina>0)
        {
            stamina-=10;
            staminaWidth -= 10;
            Vector2 temp = new Vector2(staminaWidth, staminaIMG.rectTransform.rect.height);
            staminaIMG.rectTransform.sizeDelta = temp;
        }
        else
        {
            hasStamina = false;
        }
    }

    public void RegainStamina()
    {
        if(stamina+1 >=100)
        {
            stamina = 100;
            staminaWidth = 100;
        }
        else
        {
            stamina += 4;
            staminaWidth += 4;
        }
        Vector2 temp = new Vector2(staminaWidth, staminaIMG.rectTransform.rect.height);
        staminaIMG.rectTransform.sizeDelta = temp;
        if(stamina >= 10)
        {
            hasStamina = true;
        }
        
    }

    public IEnumerator RegainStaminaOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            RegainStamina();
        }
    }

}
