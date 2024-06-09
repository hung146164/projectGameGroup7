using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerAttack : MonoBehaviour
{
    PlayerAnimation setAnim;
    private bool canAttack = true;
    private bool canSkill1 = true;
    private bool canSkill2 = true;

    [SerializeField] SkillUI skillUI;
    [SerializeField] GameObject fireObj;

    private void Start()
    {
        setAnim = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if (Input.GetKey(KeyCode.J) && canAttack)
        {
            Attack(skillUI.coolDownSkill1, skillUI.Skill1Image, -1, SkillType.BasicAttack);
        }
        else if (Input.GetKey(KeyCode.U) && canSkill1)
        {
            Attack(skillUI.coolDownSkill2, skillUI.Skill2Image, 0, SkillType.Skill1);
        }
        else if (Input.GetKey(KeyCode.O) && canSkill2)
        {
            Attack(skillUI.coolDownSkill3, skillUI.Skill3Image, 1, SkillType.Skill2);
        }
        else
        {
            setAnim.AnimState("Attack", false);
        }
    }

    private void Attack(float cooldown, Image skillImage, int attackType, SkillType skillType)
    {
        SetSkillAvailability(skillType, false);
        StartCoroutine(Cooldown(cooldown, skillImage, () => SetSkillAvailability(skillType, true)));
        setAnim.AnimState("Attack", true);
        setAnim.AnimType("isAttack", attackType);
    }

    private IEnumerator Cooldown(float time, Image skillImage, Action onCooldownComplete)
    {
        skillImage.fillAmount = 0;
        float elapsed = 0;

        while (elapsed < time)
        {
            yield return null;
            elapsed += Time.deltaTime;
            skillImage.fillAmount = elapsed / time;
        }

        skillImage.fillAmount = 1;
        onCooldownComplete.Invoke();
    }

    private void SetSkillAvailability(SkillType skillType, bool isAvailable)
    {
        switch (skillType)
        {
            case SkillType.BasicAttack:
                canAttack = isAvailable;
                break;
            case SkillType.Skill1:
                canSkill1 = isAvailable;
                break;
            case SkillType.Skill2:
                canSkill2 = isAvailable;
                break;
        }
    }

    private enum SkillType
    {
        BasicAttack,
        Skill1,
        Skill2
    }

    void SpawnFire()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.x += transform.localScale.x > 0 ? 0.5f : -0.5f;
        Instantiate(fireObj, spawnPos, Quaternion.identity).SetActive(true);
    }
}

