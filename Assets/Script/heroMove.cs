using System;
using Unity.Mathematics;
using UnityEngine;

public class heroMove : MonoBehaviour
{
    [SerializeField] private float speed=10f;
    [SerializeField] float jumpforce=10f;
    [SerializeField] GameObject skill2;
    private Rigidbody2D Rigidbody2D;
    private Animator animator;
    private bool canJump;
    private float xInput;
    private void Start()
    {
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        
        canJump = true;
    }
    private void Update()
    {
        movePlayer();
        Jump();
        Attack();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
    void movePlayer()
    {

        xInput = Input.GetAxis("Horizontal");
        float velocityPlayer = xInput * speed;
        Rigidbody2D.velocity = new Vector2(velocityPlayer, Rigidbody2D.velocity.y);

        if (xInput != 0)
        {

            flip();
            animator.SetBool("Run", true);
            if (Mathf.Abs(velocityPlayer) < 10)
            {
                animator.SetFloat("move", 1);
            }
            else
            {
                animator.SetFloat("move", 0);
            }

        }
        else
        {
            animator.SetBool("Run", false);
        }

    }

    private void flip()
    {
        Vector3 playerScale = transform.localScale;
        playerScale.x = MathF.Abs(playerScale.x) * MathF.Sign(xInput);

        transform.localScale = playerScale;

    }


    private void Jump()
    {

        if (Input.GetKey(KeyCode.M) && canJump)
        {
            canJump = false;
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpforce);
            animator.SetBool("jump", true);
            animator.SetFloat("isJump", 0);
        }
        else if (canJump)
        {
            animator.SetBool("jump", false);
        }
    }
    private void Attack()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (!canJump)
            {
                animator.SetFloat("isJump", 1);
            }
            animator.SetBool("attack", true);
            animator.SetFloat("isAttack", 0);  
        }
        else if(Input.GetKey(KeyCode.J))
        {
            animator.SetBool("attack", true);
            animator.SetFloat("isAttack", 1);
        }
        else { animator.SetBool("attack", false); }
    }

    void skill2_set()
    {
        GameObject skillclone=Instantiate(skill2,transform.position, Quaternion.identity);
        skillclone.SetActive(true);

    }
}
