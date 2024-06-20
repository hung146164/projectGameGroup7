using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] TrieuHoiBossUI thbUI;
    [SerializeField] GameObject[] Wallboss;
    [SerializeField] GameObject WalltoBoss;
    [SerializeField] GameObject HpBoss;
    [SerializeField] GameObject Key;
    [SerializeField] Text text;
    public int timedemnguoc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Key.activeSelf)
            {
                text.text = "Vui lòng tìm khóa!\n(Cuối Map)";
                text.gameObject.SetActive(true); 

                StartCoroutine(HideInfoText());
            }
            else
            {
                WalltoBoss.SetActive(false);
                foreach (GameObject wall in Wallboss)
                {
                    wall.SetActive(true);
                }
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                SetIntroBoss();
                StartCoroutine(WaitIntroBoss());
            }
        }
    }

    IEnumerator HideInfoText()
    {
        yield return new WaitForSeconds(2f); 
        text.gameObject.SetActive(false); 
    }

    void SetIntroBoss()
    {
        StartCoroutine(thbUI.DemNguocText(timedemnguoc));
    }

    IEnumerator WaitIntroBoss()
    {
        yield return new WaitForSeconds(timedemnguoc + 1);
        Boss.SetActive(true);
        HpBoss.SetActive(true);
    }
}