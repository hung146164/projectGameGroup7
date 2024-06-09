using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public event Action OnHealthChange;
    public event Action OnManaChange;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float mana;
    [SerializeField] private float maxMana;
    [SerializeField] private float armor;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    public float Health => health;
    public float MaxHealth => maxHealth;
    public float Mana => mana;
    public float MaxMana => maxMana;
    public float Armor => armor;
    public float Damage => damage;
    public float Speed => speed;
    public float JumpForce => jumpForce;

    public void ChangeDamage(float amount, bool add) => damage += add ? amount : -amount;
    public void ChangeMana(float amount, bool add)
    {
        mana += add ? amount : -amount;
        mana=Mathf.Clamp(mana, 0, maxMana);
        OnManaChange?.Invoke();
    }
    public void ChangeHealth(float amount, bool add)
    {
        health += add ? amount : -amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        OnHealthChange?.Invoke();
    }
    public void ChangeArmor(float amount, bool add) => armor += add ? amount : -amount;
    public void ChangeSpeed(float amount, bool add) => speed += add ? amount : -amount;
}
