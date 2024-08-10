using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    int score = 0;
    [SerializeField]
    TextMeshProUGUI scoreText;

    public void IncrementScore()
    {
        score++;
        UpDateDisplay();
    }

    void UpDateDisplay()
    {
        scoreText.text = score.ToString();
    }
}
