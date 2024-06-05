using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Set : MonoBehaviour
{
    public float speed_kiem;
    public Transform Player;
    void Start()
    {
        Move_Skill();
    }
    void Move_Skill()
    {
        float huong=Mathf.Sign(Player.localScale.x);
        Vector3 newScale=transform.localScale;
        newScale.x=Mathf.Abs(newScale.x)*huong;
        transform.localScale=newScale;

        Rigidbody2D rb=GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(huong*speed_kiem,0);

    }
    void Destroy_Skill()
    {
        Destroy(gameObject);
    }

    
}
