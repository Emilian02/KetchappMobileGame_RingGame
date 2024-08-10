using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameOver;
    public bool StartScreen;

    void Awake()
    {
        GameOver = false;
        StartScreen = true;
    }


    public void StartButton()
    {
        StartScreen = false;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
