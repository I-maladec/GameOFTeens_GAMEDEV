using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putin : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float spawnTime;
    public float timeToLive = 10f;

    private void Start() => spawnTime = Time.time;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player"))return;
        Destroy(gameObject);
        GameManager.Instance.score += 100;
        Debug.Log(123);
    }

    private void Update()
    {
        if(GameManager.Instance.isGameOver)return;
        transform.Translate(Vector3.left * (speed * Time.deltaTime));

        if (Time.time - spawnTime > timeToLive) Destroy(gameObject);
    }
}
