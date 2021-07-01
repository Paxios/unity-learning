using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public Slider slider;
    private int numberOfHits;
    public int goal = 2;

    private void Start()
    {
        slider.value = numberOfHits;
        slider.maxValue = goal;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            numberOfHits += 1;
            slider.value = numberOfHits;
            Destroy(other.gameObject);
            if (numberOfHits == goal)
            {
                Destroy(gameObject);
                PlayerController.IncreaseScore();
            }
        }
        if(other.CompareTag("Player"))
        {
            PlayerController.DecreaseLives();
            Destroy(gameObject);
        }
    }

}
