using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 offset;

    void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
        transform.rotation = objectToFollow.transform.rotation;
    }
}
