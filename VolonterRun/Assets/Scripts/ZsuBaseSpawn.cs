using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZsuBaseSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject zsuBase;
    [SerializeField]
    private float spawnTime;
    //spawn every _spawnTime seconds in coroutine
    private void Start()
    {
        StartCoroutine(SpawnZsuBase());
    }

    private IEnumerator SpawnZsuBase()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (GameManager.Instance.isPaused||GameManager.Instance.isGameOver)
                continue;

            Instantiate(zsuBase, transform.position, Quaternion.identity);
            
        }
    }
}
