using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] TrieuHoiBoss thbUI;
    [SerializeField] GameObject Wallboss;
    [SerializeField] GameObject HpBoss;
    public int timedemnguoc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Wallboss.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            SetIntroBoss();
            StartCoroutine(WaitIntroBoss());
        }
    }
    
    void SetIntroBoss()
    {
        StartCoroutine(thbUI.DemNguocText(timedemnguoc));
    }
    IEnumerator WaitIntroBoss()
    {
        yield return new WaitForSeconds(timedemnguoc+1);
        Boss.SetActive(true);
        HpBoss.SetActive(true);
    }
}
