using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keygame : MonoBehaviour
{
    public GameObject TextGetKey;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.PlaySFX("GetKey");
        TextGetKey.SetActive(true);
        gameObject.SetActive(false);

    }
}
