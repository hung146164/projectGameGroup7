using System;
using Unity.Mathematics;
using UnityEngine;

public class heroMove : MonoBehaviour
{
    private float trai_phai;
    private bool isJump;
    public float tocdo;
    public float jumpForce;
    public Rigidbody2D rb;
    private Animator animator;
    private bool isFacingRight = true;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        trai_phai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(trai_phai * tocdo, rb.velocity.y);
        flip();
        animator.SetFloat("move", Math.Abs(trai_phai));

        // Handle jumping when up arrow is pressed and character is grounded
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("jump", true);
        }
    }

    void flip()
    {
        if (isFacingRight && trai_phai < 0 || !isFacingRight && trai_phai > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
