using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemy  : Enemy
{
    public float force = 50f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 newPos = (collision.gameObject.transform.position - transform.position);
            playerRb.AddForce(newPos* force, ForceMode.Impulse); 
        }
    }
}
