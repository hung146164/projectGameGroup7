using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEarthController : AiFireController
{

    [SerializeField] GameObject Xuctu;
    private void Awake()
    {
        AudioManager.instance.PlayMusic("Boss2");
    }
    protected override IEnumerator SpecialSkill()
    {
        animator.SetBool("Attack", true);
        animator.SetFloat("isAttack", 1);
        yield return new WaitForSeconds(4f);
        StartCoroutine(SetRest());
    }
    protected override IEnumerator SetRest()
    {
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(SetShoot());
    }
    protected override IEnumerator SetShoot()
    {
        animator.SetBool("Attack", true);
        animator.SetFloat("isAttack", 0);
        yield return new WaitForSeconds(4f);
        animator.SetBool("Attack", false);
    }
}
