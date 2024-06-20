using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    [SerializeField] GameObject Continue;

    void ActiveButtonWingame()
    {
        Continue.SetActive(true);

    }
    IEnumerator doi2s()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
}
