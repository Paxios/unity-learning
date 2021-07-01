using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameHandler : MonoBehaviour
{
    public Text playerName;
    void Start()
    {
        playerName.text = GameObject.Find("PlayerDetail").GetComponent<Player>().pName;
    }
}
