using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float dashlevel=20f;
    [SerializeField] float dashTime=0.4f;
    [SerializeField] float runSFXInterval = 0.5f;
    bool isDashing = false;
    TrailRenderer trailRenderer;

    Rigidbody2D rb;
    PlayerAnimation setAnim;
    bool canJump=true;
    private bool isMoving = false;
    private float lastRunSFXTime;
    float xInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setAnim = GetComponent<PlayerAnimation>();
        trailRenderer = GetComponent<TrailRenderer>();
        lastRunSFXTime = -runSFXInterval;
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
        float playerVelocity = xInput * speed;
        if (!isDashing)
        {
            rb.velocity = new Vector2(playerVelocity, rb.velocity.y);
        }  
        if (xInput != 0 && !isDashing && canJump==true)
        {
            if (!isMoving)
            {
                isMoving = true;
            }
            Flip();
            setAnim.SetAnimMove(playerVelocity);

            // Chỉ phát âm thanh nếu đã đủ thời gian chờ giữa các lần phát
            if (Time.time - lastRunSFXTime >= runSFXInterval)
            {
                AudioManager.instance.PlaySFX("Run");
                lastRunSFXTime = Time.time; // Cập nhật thời gian phát âm thanh cuối cùng
            }
        }
        else
        {
            isMoving = false;
            setAnim.AnimState("Move", false);
        }
    }
    void Flip() 
    {
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * Mathf.Sign(xInput);
        transform.localScale = newScale;
    }
    void SetPlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            AudioManager.instance.PlaySFX("Jump");
            canJump = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (!canJump)
        {
            setAnim.SetAnimJump();
        }
    }
    void Dash()
    {
        StartCoroutine(WaitForDash());
        AudioManager.instance.PlaySFX("Dash");
    }
    IEnumerator WaitForDash()
    {
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashlevel, 0f);
        trailRenderer.emitting = true;
        int layerpl = gameObject.layer;
        gameObject.layer = 0;
        yield return new WaitForSeconds(dashTime);
        gameObject.layer = layerpl;
        rb.gravityScale = originalGravity;
        rb.velocity = Vector2.zero;
        trailRenderer.emitting = false;
        trailRenderer.Clear();
        isDashing = false;
    }

}