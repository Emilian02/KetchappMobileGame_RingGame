using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    int score = 0;
    int highScore = 0;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI highScoreText;

    void Start()
    {
        UpdateHighScoreText();
    }

    public void IncrementScore()
    {
        score++;
        UpDateDisplay();
    }

    public void DiamondIncrement(int value)
    {
        score += value;
        UpDateDisplay();
    }

    void UpDateDisplay()
    {
        scoreText.text = score.ToString();
    }

    public void CheckHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
