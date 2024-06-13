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
        Time.timeScale = 0f;
    }
}
