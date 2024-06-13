using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class HitBox : MonoBehaviour
{
    [SerializeField]GameObject Player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healEnemy = collision.gameObject.GetComponent<HealthSystem>();
        if (healEnemy != null && Player.tag!=collision.tag)
        {
            Hero hero = Player.GetComponent<Hero>();
            healEnemy.ChangeHealth(hero.Damage, false); 
        }
    } 
}
