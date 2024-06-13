using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVitri : MonoBehaviour
{
    public Transform EnemyPosition;
    public Vector3 cachnhanvat;
    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindWithTag("audio").GetComponent<AudioManager>();
        Move_skill();
    }
    void Move_skill()
    {
        Vector3 SpawnPos=EnemyPosition.position;
        SpawnPos.y = -2.6f;
        transform.position=SpawnPos;
        AudioManager.instance.PlaySFX("Xuctu");

    }
    void DestroySkill()
    {
        Destroy(gameObject);
    }
}
