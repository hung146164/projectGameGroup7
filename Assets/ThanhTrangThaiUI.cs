using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThanhTrangThaiUI : MonoBehaviour
{
    [SerializeField] Image HpImage;
    [SerializeField] Image ManaImage;
    [SerializeField] Text HpText;
    [SerializeField] Text ManaText;
    [SerializeField] Hero hero;
    private void Start()
    {
        hero.OnHealthChange += ChangeHealth;
        hero.OnManaChange += ChangeMana;

        //cap nhat lan dau
        ChangeHealth();
        ChangeMana();
    }
    void ChangeHealth()
    {
        HpImage.fillAmount=hero.Health/hero.MaxHealth;
        HpText.text = hero.Health.ToString();
    }
    void ChangeMana()
    {
        ManaImage.fillAmount = hero.Mana / hero.MaxMana;
        ManaText.text = hero.Mana.ToString();
    }
}
