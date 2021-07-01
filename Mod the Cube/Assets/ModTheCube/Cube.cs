 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float passedTime;
    private Material material;
    private float rotationSpeed = 10.0f;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        passedTime += Time.deltaTime;
        if(passedTime > 2f)
        {
            ChangePosition();
            ChangeScale();
            ChangeColor();
            ChangeRotationSpeed();
            passedTime = 0f;
        }

        transform.Rotate(rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void ChangePosition()
    {
        float rand_x = Random.Range(-10f, 10f);
        float rand_z = Random.Range(-10f, 10f);
        Vector3 new_pos = new Vector3(rand_x, 0f, rand_z);
        transform.position = new_pos;
    }
    
    private void ChangeScale()
    {
        int randScale = Random.Range(1, 5);
        transform.localScale =new Vector3(randScale, randScale, randScale);
    }
    private void ChangeColor()
    {
        Color c = Random.ColorHSV();
        material.color = c;
    }
    private void ChangeRotationSpeed()
    {
        rotationSpeed = Random.Range(10f, 50f);
    }
}
