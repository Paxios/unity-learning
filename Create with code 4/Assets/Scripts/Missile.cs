using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject enemy;

    void Update()
    {
        if (enemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * 15f);
            transform.LookAt(enemy.transform.position);
            transform.rotation = Quaternion.Euler(90f, transform.rotation.y, transform.rotation.z);

        }
        else
        {
            Destroy(gameObject);
        }
    }

}
