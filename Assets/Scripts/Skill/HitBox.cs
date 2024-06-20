using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class HitBox : MonoBehaviour
{
    [SerializeField]Transform Player;
    float DameHitbox=10;
    [SerializeField]float TangDamelenSoLan;
    public void SetDameHitBox(float dameHitBox)
    {
        DameHitbox=dameHitBox*TangDamelenSoLan;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag!= Player.tag)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                HealthSystemPlayer.instance.ChangeHealth(DameHitbox, false);
            }
            else if(collision.gameObject.CompareTag("enemy"))
            {
                collision.GetComponent<HealthSystemEnemy>().ChangeHealth(DameHitbox, false);
            }

        }


    } 
}
