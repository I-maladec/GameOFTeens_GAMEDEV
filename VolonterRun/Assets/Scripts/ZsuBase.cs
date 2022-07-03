using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZsuBase : MonoBehaviour
{
    public float speed = 1f;
    public float spawnTime;
    public float timeToLive = 10f;
    private void Start() => spawnTime = Time.time;


    private void OnTriggerEnter2D(Collider2D col)
    {
       

        GameManager.Instance.ZsuHit();
        Debug.Log("Zsu hit");
    }

    private void Update()
    {

        
        if(GameManager.Instance.isGameOver)return;
        transform.Translate(Vector3.left * (speed * Time.deltaTime));

        if (Time.time - spawnTime > timeToLive) Destroy(gameObject);
    }
}
