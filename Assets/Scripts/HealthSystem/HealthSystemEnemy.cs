using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystemEnemy : HealthSystem
{
    
    [SerializeField] protected Transform HealBar;
    [SerializeField] EnemyInfo enemyInfo;

    private void Reset()
    {
        this.LoadComponents();
    }

    protected void LoadComponents()
    {
        this.LoadEnemyInfo();
    }

    protected void LoadEnemyInfo()
    {
        this.enemyInfo = GetComponent<EnemyInfo>();
    }

    private void Start()
    {
        if (enemyInfo != null)
        {
            enemyInfo.OnHealthChange += DeadSound;
        }
    }

    public void ChangeHealth(float amount, bool add)
    {
        float hpChange;
        if (!add)
        {
            float standardDamage = Mathf.Ceil(amount - enemyInfo.Armor / 5);
            hpChange = -standardDamage;
        }
        else
        {
            hpChange = amount;
        }

        if (enemyInfo != null)
        {
            enemyInfo.Health += hpChange;
            HpTextPopup(hpChange);
        }
    }

    protected override void ChangeHpBar()
    {
        if (HealBar != null && enemyInfo != null)
        {
            HealBar.localScale = new Vector3(enemyInfo.Health / enemyInfo.MaxHealth, 1, 1);
        }
    }

    protected override void DeadSound()
    {
        if (enemyInfo != null && enemyInfo.Health < 1)
        {
            
            CoinManager.instance.Coins += 10;
            PlayerInfo.instance.Scores+=2;
            AudioManager.instance.PlaySFX("Coin");
        }
    }
}
