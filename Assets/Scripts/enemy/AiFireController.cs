using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AiFireController : MonoBehaviour
{
    //tốc độ của quái
    [SerializeField] protected float speed;
    [SerializeField] GameObject Win;
    //khi trong tầm này quái sẽ tấn công người chơi
    [SerializeField]protected float lineOfSite;
    //lấy vị trí người chơi
    [SerializeField]protected Transform player;
    //biến này để truy cập vào phần điểu khiển anima
    protected Animator animator;
    //Đạn của quái sẽ bắn
    [SerializeField]protected GameObject Bullet;
    //kiểu tra hướng 
    protected bool isFlipped = false;
    //vị trí spawn quái 
    [SerializeField] protected Vector3 spawnPos;
    EnemyInfo enemyInfo;
    private void Awake()
    {
        enemyInfo = GetComponent<EnemyInfo>();
        enemyInfo.OnHealthChange += SetHurt;
    }
    protected void Start()
    {
        Initialize();
        
        AudioManager.instance.PlayMusic("Boss1");
    }
    protected void Update()
    {
        LookAtPlayer();
    }
    protected void Initialize()
    {
        InvokeRepeating("SetAnimationSkill", 2, 12);
        animator = GetComponent<Animator>();
    }
    protected virtual void SetAnimationSkill()
    {
        StartCoroutine(SpecialSkill());
    }
    protected void SetSkill()
    {
        StartCoroutine(SpecialSkill());
    }

    protected virtual IEnumerator SpecialSkill()
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
    void Shoot()
    {
        Instantiate(Bullet,transform.position,Quaternion.identity).SetActive(true);

    }
    protected virtual IEnumerator SetRest()
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
        if (enemyInfo.Health < 1)
        {
            StartCoroutine(Dead());
        }
        StartCoroutine(ResetHurt());
    }
    protected IEnumerator Dead()
    {
        animator.SetBool("Died", true);
        Win.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
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

}