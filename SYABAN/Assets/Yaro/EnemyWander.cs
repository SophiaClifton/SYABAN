using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            //move right
            rb2D.velocity = new Vector2(speed, 0f);
        }
        else
        {
            //move left
            rb2D.velocity = new Vector2(-speed, 0f);
        }
    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > 0.00001f;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb2D.velocity.x)), transform.localScale.y);
    }
}
