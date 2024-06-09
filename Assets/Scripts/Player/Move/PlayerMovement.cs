using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;
    Rigidbody2D rb;
    PlayerAnimation setAnim;
    bool canJump;


    float xInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setAnim = GetComponent<PlayerAnimation>();
        canJump = true;
    }
    private void Update()
    {
        SetPlayerMoveHorizontal();
        SetPlayerJump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            setAnim.AnimState("Jump", false);
        }
    }
    void SetPlayerMoveHorizontal()
    {
        xInput = Input.GetAxis("Horizontal");
        if (xInput != 0)
        {
            float playerVelocity = xInput * speed;
            rb.velocity = new Vector2(playerVelocity, rb.velocity.y);
            setAnim.SetAnimMove(playerVelocity);
            flip();
        }
        else
        {
            setAnim.AnimState("Move", false);
        }
    }
    void flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * Mathf.Sign(xInput);
        transform.localScale = newScale;
    }
    void SetPlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (!canJump)
        {
            setAnim.SetAnimJump();
        }
    }
    
}