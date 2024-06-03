using System;
using UnityEngine;

public class heroMove : MonoBehaviour
{
    private float trai_phai;
    private bool isJump;
    public float tocdo;
    public float jumpForce;
    public float doubleJumpForce; // Lực nhảy double
    public Rigidbody2D rb;
    private Animator animator;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isDoubleJumpAvailable = false; // Biến để kiểm tra có thể nhảy double hay không

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpForce = 10;
        doubleJumpForce = 12; // Thiết lập lực nhảy double
    }

    // Update is called once per frame
    void Update()
    {
        trai_phai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(trai_phai * tocdo, rb.velocity.y);
        flip();
        animator.SetFloat("move", Math.Abs(trai_phai));

        // Handle jumping when up arrow is pressed and character is grounded
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("jump", true);
                isDoubleJumpAvailable = true;
            }
            else if (isDoubleJumpAvailable)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                animator.SetBool("jump", true);
                isDoubleJumpAvailable = false;
            }
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
