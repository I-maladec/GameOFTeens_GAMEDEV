using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopomogaItem : MonoBehaviour
{
    public float speed = 1f;
    public float spawnTime;
    public float timeToLive = 10f;

    private void Start() => spawnTime = Time.time;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))return;
        Destroy(gameObject);
        GameManager.Instance.DopomogaCollected();

    }

    private void Update()
    {
        if(GameManager.Instance.isGameOver)return;
        transform.Translate(Vector3.left * (speed * Time.deltaTime));
        if (Time.time - spawnTime > timeToLive) Destroy(gameObject);
    }
}