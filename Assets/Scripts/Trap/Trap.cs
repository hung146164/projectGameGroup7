using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap :MonoBehaviour
{
    [SerializeField] protected float damageTrap;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healEnemy = collision.gameObject.GetComponent<HealthSystem>();
        if (healEnemy != null && collision.gameObject.CompareTag("Player"))
        {
            ApplyTrapEffect(healEnemy);
        }
    }

    protected abstract void ApplyTrapEffect(HealthSystem healEnemy);
}
