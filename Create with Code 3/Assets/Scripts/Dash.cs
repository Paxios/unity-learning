using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public static bool fastMode = false;

    private PlayerController playerControllerScript;
    private int points;

    void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();        
    }

    void Update()
    {
        if (!playerControllerScript.gameOver && playerControllerScript.playerReachedStartPoint)
        {
            if (fastMode)
                points += 2;
            else
                points += 1;

            if (Input.GetKey(KeyCode.X))
                fastMode = true;
            else
                fastMode = false;

            print(points);
        }
        else
            print("Game over! " + points);
    }
}
