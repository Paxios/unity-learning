using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int score = 0;
    public static int lives = 3;


    private float horizontalInput;
    private float veritaclInput;
    private float speed = 25.0f;
    private float xRange = 15f;
    private float zRange = 15f;
    public GameObject projectilePrefab;

    private void Start()
    {
        print("Score: " + score);
        print("Lives: " + lives);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        veritaclInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * veritaclInput);

        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        else if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        if (transform.position.z > zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        if (transform.position.z < 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    public static void IncreaseScore()
    {
        score++;
        print("Score: " + score);
    }
    public static void DecreaseLives()
    {
        if(lives > 0)
            lives--;
        if(lives == 0)
        {
            print("Game over!");
        }
        print("Lives: " + lives);
    }
}
