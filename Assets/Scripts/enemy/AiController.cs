using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AiController : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    [SerializeField] Transform player;
    protected Animator animator;
    [SerializeField] GameObject Bullet;
    protected bool isFlipped = false;
    protected Hero enemy;
    public GameObject Win;
    public Vector3 spawnPos;
    private void Start()
    {
        Initialize();
        HandleAttack(2, 12);
        AudioManager.instance.PlayMusic("Boss1");
    }
    private void Update()
    {
        HandleUpdate();
    }
    protected void Initialize()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Hero>();
        enemy.OnHealthChange += CheckHealthBoss;
    }
    protected void HandleUpdate()
    {
        LookAtPlayer();
    }
    protected void HandleAttack(float timeTostart,float RepeatTime)
    {
        InvokeRepeating("SetAnimationSkill", timeTostart, RepeatTime);
    }
    protected virtual void SetAnimationSkill()
    {
        StartCoroutine(SpecialSkill());
    }

    public virtual IEnumerator SpecialSkill()
    {
        animator.SetBool("Attack", true);
        animator.SetFloat("isAttack", 1);
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        while (distanceFromPlayer > 3f) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            distanceFromPlayer = Vector2.Distance(player.position, transform.position);
            yield return null; // Chờ đến frame tiếp theo
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SetRest());
    }

    protected virtual IEnumerator SetShoot()
    {
        animator.SetBool("Attack", true); 
        animator.SetFloat("isAttack", 0);
        yield return new WaitForSeconds(4f);
        animator.SetBool("Attack", false);
    }

    public virtual IEnumerator SetRest()
    {
        while (Vector2.Distance(transform.position, spawnPos) > 0.1f) // Di chuyển về vị trí spawn
        {
            transform.position = Vector2.MoveTowards(transform.position, spawnPos, speed * Time.deltaTime);
            yield return null; // Chờ đến frame tiếp theo
        }
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(4f);
        StartCoroutine(SetShoot());
    }
    protected void SetHurt()
    {
        animator.SetBool("Hurt", true);
        StartCoroutine(ResetHurt());
    }

    protected  IEnumerator ResetHurt()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Hurt", false);
    }
    protected void LookAtPlayer()
    {
        Vector3 scale = transform.localScale;
        if (player.position.x > transform.position.x && isFlipped)
        {
            scale.x= 10;
            isFlipped = false;
        }
        else if (player.position.x < transform.position.x && !isFlipped)
        {
            scale.x = -10;
            isFlipped = true;
        }
        transform.localScale = scale;
    }

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    protected void Shoot()
    {
        Instantiate(Bullet, transform.position, Quaternion.identity).SetActive(true);
    }
    protected void CheckHealthBoss()
    {
        SetHurt();
        if (enemy.Health < 1)
        {
            AudioManager.instance.PlaySFX("Win");
            animator.SetBool("Died", true);
            
            Win.SetActive(true);
        }
    }
    public virtual void SFXSpeciSkill()
    {
        AudioManager.instance.PlaySFX("Exploi");

    }
}