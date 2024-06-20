using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaiMove : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    EnemyInfo enemyInfo;
    public float lineOfSite;
    public float rangeAttack;

    public Transform player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyInfo = GetComponent<EnemyInfo>();

        enemyInfo.OnHealthChange += Hurt;
    }
    private void Update()
    {
        MoveQuai();
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
    }

    void MoveQuai()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        bool check = transform.position.x < player.position.x;
        float huong = Mathf.Abs(transform.localScale.x);
        transform.localScale = new Vector2(check ? huong : -huong, transform.localScale.y);
        if (distanceToPlayer <= rangeAttack)
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("isMoving", 1);
        }
        else if (distanceToPlayer <= lineOfSite)
        {
            animator.SetFloat("isMoving", 0);
            animator.SetBool("Move", true);
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * enemyInfo.Speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Move", false);
        }
    }
    void Hurt()
    {
        animator.SetBool("GetDame", true);
        if (enemyInfo.Health < 1)
        { 
            animator.SetFloat("isGetDame", 1);
            AudioManager.instance.PlaySFX("Dead");
        }
        else
        {
            StartCoroutine(WaitSecond());
        }
    }
    void DisableQuai()
    {
        gameObject.SetActive(false);
    }
    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("GetDame", false);
    }

}
