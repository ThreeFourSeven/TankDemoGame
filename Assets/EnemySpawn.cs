using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public const int waveCount = 3;
    public GameObject smallSpawner;
    public GameObject mediumSpawner;
    public GameObject largeSpawner;
    public GameObject player;
    public float spawnRadius = 5;
    float[] waveLengths = new float[waveCount]; 
    int[] spawns = new int[waveCount * 3];
    int currentWave = 0;
    float timeCtr = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < waveCount; i++)
        {
            waveLengths[i] = i * 10.0f;
            int c = i + 1;
            spawns[i * 3] = c;
            spawns[i * 3 + 1] = c-1;
            spawns[i * 3 + 2] = c-2;
        }
        smallSpawner.GetComponent<EnemySpawner>().player = player;
        mediumSpawner.GetComponent<EnemySpawner>().player = player;
        largeSpawner.GetComponent<EnemySpawner>().player = player;
        smallSpawner.GetComponent<EnemySpawner>().spawnRadius = spawnRadius;
        mediumSpawner.GetComponent<EnemySpawner>().spawnRadius = spawnRadius;
        largeSpawner.GetComponent<EnemySpawner>().spawnRadius = spawnRadius;
    }

    // Update is called once per frame
    void Update()
    {
        timeCtr += Time.deltaTime;
        if (timeCtr >= waveLengths[currentWave])
        {
            if(spawns[currentWave * 3] > 0)
                smallSpawner.GetComponent<EnemySpawner>().Spawn(spawns[currentWave * 3]);
            if (spawns[currentWave * 3 + 1] > 0)
                mediumSpawner.GetComponent<EnemySpawner>().Spawn(spawns[currentWave * 3 + 1]);
            if (spawns[currentWave * 3 + 2] > 0)
                largeSpawner.GetComponent<EnemySpawner>().Spawn(spawns[currentWave * 3 + 2]);
            currentWave++;
            if (currentWave >= waveCount)
                currentWave = 0;
            timeCtr = 0.0f;
        }

    }
}
