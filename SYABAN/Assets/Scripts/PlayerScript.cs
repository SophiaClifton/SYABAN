using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Image HP; 
    public float HPWidth;
    public Image staminaIMG; 
    public float staminaWidth;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private LayerMask blockingLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float health;
    [SerializeField] private float stamina;
    private float horizontal;
    private bool isFacingRight = true;
    public Animator animator;
    private bool hasStamina = true;//use for determining if player can shoot /hit

    // Start is called before the first frame update
    void Start()
    {
        HPWidth = HP.rectTransform.rect.width;
        staminaWidth = staminaIMG.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
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

    public void loseStamina()
    {
        
        if(stamina>0)
        {
            stamina-=100;
            staminaWidth -= 100;
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
        if(stamina+75 >=100)
        {
            stamina = 100;
            staminaWidth = 100;
        }
        else
        {
            stamina += 75;
            staminaWidth += 75;
            Vector2 temp = new Vector2(staminaWidth, staminaIMG.rectTransform.rect.height);
            staminaIMG.rectTransform.sizeDelta = temp;

            if(stamina >= 100)
            {
                hasStamina = true;
            }
        }
    }

    IEnumerator RegainStaminaOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f); // Wait 1 sec
            RegainStamina(); // Increase stamina by 75
        }
    }

}
