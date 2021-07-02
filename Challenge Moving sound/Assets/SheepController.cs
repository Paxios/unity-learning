using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private float speed = 5f;
    private bool isForward;
    void Start()
    {

        InvokeRepeating("Move", 0f,2f);
    }

    private void Update()
    {
        Vector3 dir = Vector3.forward;
        if (!isForward)
            dir = Vector3.back;
        transform.Translate(dir * Time.deltaTime * speed);
    }

    public void Move()
    {
        isForward = !isForward;

    }
}
