using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float spawnRadius = 5;

    private void SpawnOne()
    {
        GameObject go = Instantiate(enemy, transform.position + new Vector3(Random.Range(0.0f, spawnRadius), Random.Range(0.0f, spawnRadius), 0.0f), Quaternion.identity);
        go.GetComponent<Enemy>().target = player;
    }

    public void Spawn(int count)
    {
        int i = 0;
        while (i < count)
        {
            SpawnOne();
            i++;
        }
    }
}
