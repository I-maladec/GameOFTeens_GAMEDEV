using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject mine;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 10f;
    private void Start()
    {
        StartCoroutine(SpawnMines());
    }

    private IEnumerator SpawnMines()
    {
        while (true)
        {
            var random = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(random);
            if (!GameManager.Instance.isPaused)
                Instantiate(mine, transform.position, Quaternion.identity);
            if(GameManager.Instance.isGameOver)
                yield break;
        }
    }
}