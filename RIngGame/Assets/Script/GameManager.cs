using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    public bool GameOver;
    public bool Playing;
    public bool HasPlayAd;

    void Awake()
    {
        GameOver = false;
        Playing = false;
        HasPlayAd = false;
    }


    public void StartButton()
    {
        Playing = true;
        spawner.SetActive(true);
    }

    public void RestartButton()
    {
        FindAnyObjectByType<UIScore>().CheckHighScore();
        SceneManager.LoadScene("Game");
    }
}
