using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHanlder : MonoBehaviour
{
    public InputField inputField;
    public GameObject player;

    public void GoToGame()
    {
        player.GetComponent<Player>().pName = inputField.text;
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(0);
    }
}
