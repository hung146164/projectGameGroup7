using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    [SerializeField] public Image Skill1Image;
    [SerializeField] public Image Skill2Image;
    [SerializeField] public Image Skill3Image;
    [SerializeField] public float coolDownSkill1 = 1f;
    [SerializeField] public float coolDownSkill2 = 2f;
    [SerializeField] public float coolDownSkill3 = 1f;

    private void Start()
    {
        Skill1Image.fillAmount = 1;
        Skill2Image.fillAmount = 1;
        Skill3Image.fillAmount = 1;
    }
}