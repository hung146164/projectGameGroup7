using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanDuoitheo : MonoBehaviour
{
    public float velocitySkill;
    public Transform PlayerPosition;
    public Transform EnemyPosition;
    private void Start()
    {
        Move_skill();
    }

    void Move_skill()
    {
        float direction = Mathf.Sign(PlayerPosition.localScale.x);

        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Abs(newScale.x) * direction;
        transform.localScale = newScale;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 moveDir = (EnemyPosition.position - PlayerPosition.position).normalized * velocitySkill;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
    }
    void DestroySkill()
    {
        Destroy(gameObject);
        StartCoroutine(UnloadUnusedAssets());
    }
    private IEnumerator UnloadUnusedAssets()
    {
        yield return Resources.UnloadUnusedAssets();
        Debug.Log("Đã giải phóng tài nguyên không sử dụng.");
    }
}   
