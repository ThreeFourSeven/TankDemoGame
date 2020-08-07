using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    public GameObject smallSpawner;
    public GameObject mediumSpawner;
    public GameObject largeSpawner;
    public GameObject player;
    public float spawnRadius = 5;

    // Start is called before the first frame update
    void Start()
    {
        smallSpawner.GetComponent<EnemySpawner>().player = player;
        mediumSpawner.GetComponent<EnemySpawner>().player = player;
        largeSpawner.GetComponent<EnemySpawner>().player = player;
        smallSpawner.GetComponent<EnemySpawner>().spawnRadius = spawnRadius;
        mediumSpawner.GetComponent<EnemySpawner>().spawnRadius = spawnRadius;
        largeSpawner.GetComponent<EnemySpawner>().spawnRadius = spawnRadius;
    }

    public void SpawnSmall() 
    {
        smallSpawner.GetComponent<EnemySpawner>().Spawn(1);
    }

    public void SpawnMedium() 
    {
        mediumSpawner.GetComponent<EnemySpawner>().Spawn(1);
    }

    public void SpawnLarge() 
    {
        largeSpawner.GetComponent<EnemySpawner>().Spawn(1);
    }
}
