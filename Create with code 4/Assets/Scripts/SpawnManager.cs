using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject[] powerupPrefabs;
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9f;
    private int waveCount = 2;

    void Start()
    {
        SpawnEnemyWave(waveCount);
    }

    private void Update()
    {
        int numOfEnemiesOnField = FindObjectsOfType<Enemy>().Length;
        if(numOfEnemiesOnField == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
        }
    }

    void SpawnEnemyWave(int numberOfEnemies)
    {
        if(waveCount == 3)
        {
            Instantiate(boss, GenerateSpawnPosition(), boss.transform.rotation);
        }
        for(int i = 0;i< numberOfEnemies; i++)
        {
            int randomEnemyNumber = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemyNumber], GenerateSpawnPosition(), enemyPrefabs[randomEnemyNumber].transform.rotation);
        }
        foreach (GameObject powerUp in powerupPrefabs)
        {
            Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
        }

    }

    private Vector3 GenerateSpawnPosition()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(posX, 0.13f, posZ);

    }

}
