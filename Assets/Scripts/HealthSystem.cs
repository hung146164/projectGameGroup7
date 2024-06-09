using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    Hero player;
    [SerializeField]GameObject damepopup;
    [SerializeField] Transform HealBar;
    private void Start()
    {
        player = GetComponent<Hero>();
    }
    
    public void ChangeHealth(float Amount,bool add)
    {
        float standardDamage = Amount - player.Armor / 5;
        player.ChangeHealth(standardDamage, add);
        DamePopup(standardDamage);
    }
    public void DamePopup(float standardDamage)
    {
        Vector2 SpawnPos = transform.position;
        SpawnPos.y += 0.5f;
        TextMeshPro dameText = Instantiate(damepopup, SpawnPos, Quaternion.identity).GetComponent<TextMeshPro>();
        dameText.text= standardDamage.ToString()+$" Dame";
        HealBar.localScale = new Vector3(player.Health / player.MaxHealth,1,1);
    }
}
