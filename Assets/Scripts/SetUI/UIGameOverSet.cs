using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverSet : MonoBehaviour
{
    
    void setTimescale()
    {
        //doi 2s;
        StartCoroutine(doi2s());
    }
    IEnumerator doi2s()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;

    }
}
