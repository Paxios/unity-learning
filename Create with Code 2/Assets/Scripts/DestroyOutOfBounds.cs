using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30f;
    public float lowerBound = -10f;
    public float sideBound = 20f;
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        } else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            PlayerController.DecreaseLives();
        }

        if ((transform.position.x > sideBound) || (transform.position.x < -sideBound))
        {
            Destroy(gameObject);
            PlayerController.DecreaseLives();
        }
    }
}
