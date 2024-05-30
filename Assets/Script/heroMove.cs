using System;
using UnityEngine;

public class heroMove : MonoBehaviour
{

    private float trai_phai;
    public float tocdo;
    public Rigidbody2D rb;
    private Animator animator;
    private bool isfacingRight = true;
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
    }

    void flip()
    {
        if (isfacingRight && trai_phai < 0 || !isfacingRight && trai_phai > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 kichthuoc = transform.localScale;
            kichthuoc.x = kichthuoc.x * -1;
            transform.localScale = kichthuoc;
        }
    }
}
