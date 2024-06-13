using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Hero player;
    [SerializeField]GameObject GameOverUI;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<Hero>();
        player.OnHealthChange += Died;
    }
    public void AnimState(string state, bool status)
    {
        animator.SetBool(state, status);
    }
    public void AnimType(string state, float status)
    {
        animator.SetFloat(state, status);
    }
    public void SetAnimAttack(float stateAttack)
    {
        animator.SetBool("Attack", true);
        animator.SetFloat("isAttack", stateAttack);
    }
    public void SetAnimMove(float playerVelocity)
    {
   
        AnimState("Move", true);
        if (Mathf.Abs(playerVelocity) < 3f)
        {
            AnimType("isMove", -1);
        }
        else
        {
            AnimType("isMove", 1);
        }
    }
    public void SetAnimJump()
    {
        AnimState("Jump", true);
        if (rb.velocity.y > 0)
        {
            AnimType("isJump", 0);
        }
        else if (rb.velocity.y < 0)
        {
            AnimType("isJump", 1);
        }
    }
    public void SetHurt()
    {
        animator.SetBool("Hurt", true);
        StartCoroutine(ResetHurt());
    }
    IEnumerator ResetHurt()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Hurt", false);
    }

    void Died()
    {
        SetHurt();
        if (player.Health<1)
        {
            AnimState("Died", true);
            AudioManager.instance.PlaySFX("GameOver");
        }
    }
    void activeOverUI()
    {
        GameOverUI.SetActive(true);
       
    }
}