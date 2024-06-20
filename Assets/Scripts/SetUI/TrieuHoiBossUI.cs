using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrieuHoiBossUI : MonoBehaviour
{
    [SerializeField] Text TextdemNguoc;
    [SerializeField] Text HpText;
    [SerializeField] Image HpImage;
    [SerializeField] EnemyInfo enemyInfo;

    private void Start()
    {
        enemyInfo.OnHealthChange += SetHpUI;

        SetHpUI();
    }
    public IEnumerator DemNguocText(int timedemnguoc)
    {
        for(int i= timedemnguoc; i>=1;i--)
        {
            TextdemNguoc.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        TextdemNguoc.text = "Awake!";
        yield return new WaitForSeconds(1);
        TextdemNguoc.text = "";
    }
    private void SetHpUI()
    {
        HpImage.fillAmount = enemyInfo.Health / enemyInfo.MaxHealth;
        HpText.text = $"{enemyInfo.Health} / {enemyInfo.MaxHealth}";
    }
    private void OnDestroy()
    {
        if(enemyInfo!=null)
        {
            enemyInfo.OnHealthChange -= SetHpUI;
        }
    }
    

}
