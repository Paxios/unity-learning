using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float xBoundary = 10f;
    public float speed = 20f;
    public int bounces;
    private float minWidth = 0.3f;
    private const float maxXDirection = 3f;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        scoreText.text = "Score " + bounces;

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y);
        }
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        float randomForce = Random.Range(500f, 750f);
        float randomXDirection = Random.Range(-maxXDirection, maxXDirection);
        collision.gameObject.GetComponent<Rigidbody>().AddForce((Vector3.up * Time.deltaTime * randomForce) + (Vector3.right * randomXDirection), ForceMode.Impulse);
        UpdateScore();
        DecreaseSize();
    }

    public void UpdateScore()
    {
        bounces++;
        scoreText.text = "Score " + bounces;
    }

    public void DecreaseSize()
    {
        if (gameObject.transform.localScale.x > minWidth)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 1.1f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}
