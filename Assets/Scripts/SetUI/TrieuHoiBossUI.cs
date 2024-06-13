using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrieuHoiBossUI : MonoBehaviour
{
    [SerializeField] Text TextdemNguoc;
    [SerializeField] Text HpText;
    [SerializeField] Image HpImage;
    [SerializeField] Hero Boss;

    private void Start()
    {
        Boss.OnHealthChange += SetHpUI;

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
        HpImage.fillAmount = Boss.Health / Boss.MaxHealth;
        HpText.text = $"{Boss.Health} / {Boss.MaxHealth}";
    }

}
