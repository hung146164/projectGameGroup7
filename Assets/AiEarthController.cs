using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEarthController : AiController
{
    [SerializeField] GameObject Xuctu;
    private void Start()
    {
        base.Initialize();
        base.HandleAttack(2,14);
    }

    private void Update()
    {
        base.HandleUpdate();
    }
    protected override void SetAnimationSkill()
    {
        StartCoroutine(SpecialSkill());
    }
    public override IEnumerator SpecialSkill()
    {
        animator.SetBool("Attack", true);
        animator.SetFloat("isAttack", 1);
        yield return new WaitForSeconds(4f);
        StartCoroutine(SetRest());
    }
    public override IEnumerator SetRest()
    {
        animator.SetBool("Attack", false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(SetShoot());
    }
    public void TaoXuctu()
    {
        Instantiate(Xuctu).SetActive(true);
    }
    protected override IEnumerator SetShoot()
    {
        animator.SetBool("Attack", true);
        animator.SetFloat("isAttack", 0);
        yield return new WaitForSeconds(4f);
        animator.SetBool("Attack", false);
    }
}
