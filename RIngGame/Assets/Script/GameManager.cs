using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawner;
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
        spawner.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
