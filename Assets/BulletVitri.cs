using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVitri : MonoBehaviour
{
    public Transform EnemyPosition;
    public Vector3 cachnhanvat;
    void Start()
    {
        Move_skill();
    }
    void Move_skill()
    {
        Vector3 SpawnPos=EnemyPosition.position;
        SpawnPos.y = -2.6f;
        transform.position=SpawnPos;
    }
    void DestroySkill()
    {
        Destroy(gameObject);
        StartCoroutine(UnloadUnusedAssets());
    }
    private IEnumerator UnloadUnusedAssets()
    {
        yield return Resources.UnloadUnusedAssets();
    }
}
