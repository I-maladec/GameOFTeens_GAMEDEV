using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDisplay : MonoBehaviour
{
    public GameObject[] hearts;

    void Start()
    {
        hearts = new GameObject[transform.childCount];
        for (var i = 0; i < transform.childCount; i++)
            hearts[i] = transform.GetChild(i).gameObject;
    }
    public void SetHearts(int numHearts)
    {
        for (var i = 0; i < hearts.Length; i++) 
            hearts[i].SetActive(i < numHearts);
    }
}
