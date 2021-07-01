using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject focalPoint;
    private Rigidbody playerRB;
    public float speed = 200f;
    private bool hasPowerup;
    private bool hasJumped;
    private float powerupStrength = 3f;
    public GameObject powerUp;
    public GameObject missile;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        powerUp.transform.position = transform.position;
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(forwardInput * focalPoint.transform.forward * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            hasJumped = true;
            playerRB.AddForce(Vector3.up * 1000f);
            StartCoroutine(SmashDown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerUp.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
        if (other.CompareTag("Powerup2"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Missile m = missile.GetComponent<Missile>();
                m.enemy = enemy;
                Instantiate(m, transform.position, m.transform.rotation);
                                
            }
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayVector = collision.gameObject.transform.position - transform.position;
            enemyRB.AddForce(awayVector * powerupStrength, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Ground") && hasJumped)
        {
            Collider[] gos = Physics.OverlapSphere(transform.position, 4);
            foreach (Collider enemy in gos)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    Vector3 awayVector = enemy.gameObject.transform.position - transform.position;
                    enemy.GetComponent<Rigidbody>().AddForce(awayVector * 5f, ForceMode.Impulse);
                }
            }
            hasJumped = false;
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUp.SetActive(false);
    }

    IEnumerator SmashDown()
    {
        yield return new WaitForSeconds(0.3f);
        playerRB.AddForce(Vector3.down * 3000f);
    }
}
