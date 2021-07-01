using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private Rigidbody bossRB;
    private bool hasJumped;

    void Start()
    {
        bossRB = GetComponent<Rigidbody>();
        InvokeRepeating("Smash", 4f, 3f);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
            Collider[] gos = Physics.OverlapSphere(transform.position, 4);
            foreach (Collider enemy in gos)
            {
                if (enemy.CompareTag("Player") && hasJumped)
                {
                    Vector3 awayVector = enemy.gameObject.transform.position - transform.position;
                    enemy.GetComponent<Rigidbody>().AddForce(awayVector * 5f, ForceMode.Impulse);
                }
            }
            hasJumped = false;
        }
    }

    private void Smash()
    {
        bossRB.AddForce(Vector3.up * 1000f);
        StartCoroutine(SmashDown());
        hasJumped = true;
    }
    IEnumerator SmashDown()
    {
        yield return new WaitForSeconds(0.3f);
        bossRB.AddForce(Vector3.down * 3000f);
    }
}
