using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameHandlerScript : MonoBehaviour
{
    public GameObject ball;
    public TextMeshProUGUI text;
    public static int score;

    private float passedTime = 5f;
    void Update()
    {
        passedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (passedTime > 1f)
            {
                CreateNewBall();
                passedTime = 0f;
            }
        }
        
    }

    private void CreateNewBall()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 1f;
        worldPosition.y = 5f;
        Instantiate(ball,worldPosition,Quaternion.identity);
    }

    public void IncreasePoints()
    {
        score++;
        text.SetText("Score: "+ score);
    }

}
