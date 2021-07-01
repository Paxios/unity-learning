using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject player;
    public float speed = 200f;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); 
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            enemyRb.AddForce((transform.position - other.gameObject.transform.position) * 20f, ForceMode.Impulse);
            Destroy(other.gameObject);
        }
    }
}
