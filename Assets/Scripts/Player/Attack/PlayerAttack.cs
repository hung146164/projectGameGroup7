using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerAttack : MonoBehaviour
{
    PlayerAnimation setAnim;
    private bool canSkill1 = true;
    private bool canSkill2 = true;
    private bool canSkill3 = true;
    private bool canSkill4 = true;
    private bool isDashing = false;
    private bool isWaiting = false; // New flag to control waiting time

    [SerializeField] SkillUI skillUI;
    [SerializeField] GameObject fireObj;
    [SerializeField] float waitForNextSkillTime=0.3f;

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

        if (Input.GetKey(KeyCode.J) && canSkill1&&!isWaiting)
        {
            isWaiting = true;
            Attack(skillUI.coolDownSkill1, skillUI.Skill1Image, -1, SkillType.Skill1);
            AudioManager.instance.PlaySFX("Attack");
        }
        else if (Input.GetKey(KeyCode.U) && canSkill2&& !isWaiting)
        {
            isWaiting = true;
            Attack(skillUI.coolDownSkill2, skillUI.Skill2Image, 0, SkillType.Skill2);
            AudioManager.instance.PlaySFX("Fire");

        }
        else if (Input.GetKey(KeyCode.O) && canSkill3 && !isWaiting)
        {
            isWaiting = true;
            Attack(skillUI.coolDownSkill3, skillUI.Skill3Image, 1, SkillType.Skill3);
            AudioManager.instance.PlaySFX("Shield");

        }
        else if (Input.GetKey(KeyCode.I) && canSkill4 && !isDashing && !isWaiting)
        {
            isWaiting = true;
            Attack(skillUI.coolDownSkill4, skillUI.Skill4Image, 2, SkillType.Skill4);
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
        StartCoroutine(WaitBetweenSkills(waitForNextSkillTime)); // Start the waiting coroutine
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
            case SkillType.Skill1:
                canSkill1 = isAvailable;
                break;
            case SkillType.Skill2:
                canSkill2 = isAvailable;
                break;
            case SkillType.Skill3:
                canSkill3 = isAvailable;
                break;
            case SkillType.Skill4:
                canSkill4 = isAvailable;
                break;
        }
    }

    private IEnumerator WaitBetweenSkills(float waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }

    private enum SkillType
    {
        Skill1,
        Skill2,
        Skill3,
        Skill4,
    }

    void SpawnFire()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.x += transform.localScale.x > 0 ? 0.5f : -0.5f;
        Instantiate(fireObj, spawnPos, Quaternion.identity).SetActive(true);
    }
}

