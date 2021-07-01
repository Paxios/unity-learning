using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public Vector3 spawnPosition = new Vector3(25,0,0);
    PlayerController playerControllerScript;
    private float startDelay = 1.5f;
    private float repeatDelay = 1.5f;

    void Start()
    {
        //Should've used Coroutines.
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver && playerControllerScript.playerReachedStartPoint)
        {
            int randPrefab = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[randPrefab], spawnPosition, obstaclePrefab[randPrefab].transform.rotation);
        }
    }
}
