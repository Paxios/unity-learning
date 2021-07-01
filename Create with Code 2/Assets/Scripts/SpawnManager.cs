using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15f;
    private float spawnPosZ = 15f;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        int side = Random.Range(0, 3);
        Vector3 position = Vector3.zero;
        Quaternion rotation = animalPrefabs[animalIndex].transform.rotation;

        switch (side)
        {
            case 0:
                {
                    float xPos = Random.Range(-spawnRangeX, spawnRangeX);
                    position = new Vector3(xPos, 0, spawnPosZ);
                    break;
                }
            case 1: {
                    float zPos = Random.Range(0, 15f);
                    position = new Vector3(-spawnRangeX, 0, zPos);
                    rotation = Quaternion.Euler(rotation.eulerAngles - new Vector3(0, 90,0));
                    break; }
            case 2: {
                    float zPos = Random.Range(0, 15f);
                    position = new Vector3(spawnRangeX, 0, zPos);
                    rotation = Quaternion.Euler(rotation.eulerAngles + new Vector3(0,90,0));
                    break;
                }
            default: break;
        }


        Instantiate(animalPrefabs[animalIndex], position, rotation);
    }
}
