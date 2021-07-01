using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    string player_key = "v";
    string player2_key = "c";
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        string key = player_key;
        if(tag != "Player")
        {
            key = player2_key;
        }
        if (Input.GetKeyDown(key))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}
