using UnityEngine;



public class BallHandler : MonoBehaviour
{
    private bool alreadyCounted = false;
    private float passedTime = 0f;


    void Update()
    {
        passedTime += Time.deltaTime;
        print(passedTime);
        if (passedTime > 8)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "End" && !alreadyCounted)
        {
            alreadyCounted = true;
            FindObjectOfType<GameHandlerScript>().IncreasePoints();
        }
    }
}
