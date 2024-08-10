using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class UIAnimation : MonoBehaviour
{
    [Header("Start Screen Variables")]
    [SerializeField]
    GameObject startScreen;
    [SerializeField]
    RectTransform title;
    [SerializeField]
    RectTransform tutorial;
    [SerializeField]
    RectTransform startButton;
    [SerializeField]
    float tweenDuration;
    [Header("Lose Screen Variables")]
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    RectTransform GameOverTitle;
    [SerializeField]
    RectTransform restartButton;
    [Header("ScoreUi")]
    [SerializeField]
    GameObject scoreScreen;
    [SerializeField]
    RectTransform score;

    bool startIsActive;

    void Start()
    {
        DOTween.SetTweensCapacity(500, 50);
        startIsActive = true;
    }


    public async void StartButton()
    {
        await StartPanelOutro();
        startIsActive = false;
        startScreen.SetActive(false);
        scoreScreen.SetActive(true);
    }

    async Task StartPanelOutro()
    {
        title.DOAnchorPosY(750, tweenDuration);
        await startButton.DOAnchorPosY(-500, tweenDuration).AsyncWaitForCompletion();
    }

    public void GameOverPanelIntro()
    {
        gameOverPanel.SetActive(true);
        GameOverTitle.DOAnchorPosY(894, tweenDuration);
        restartButton.DOAnchorPosY(-887, tweenDuration);
        score.DOAnchorPos(new Vector2(-291, -516), tweenDuration);
    }

}
