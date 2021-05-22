using UnityEngine;
using System.Collections;
using System;

public class WaterController : MonoBehaviour
{
    public GameObject[] waters;
    private void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(time());
    }
    IEnumerator time()
    {
        for (int i = 0; i < waters.Length; i++)
        {
            waters[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
