using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class UIAnimation : MonoBehaviour
{
    [SerializeField]
    GameManager gm;
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
    [Header("Ad Button")]
    [SerializeField]
    GameObject adPanel;
    [SerializeField]
    RectTransform adButton;
    [Header("ScoreUi")]
    [SerializeField]
    GameObject scoreScreen;
    [SerializeField]
    RectTransform score;


    void Start()
    {
        DOTween.SetTweensCapacity(500, 50);
    }


    public async void StartButton()
    {
        await StartPanelOutro();
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
        gm.Playing = false;
        if (!gm.HasPlayAd)
        {
            adPanel.SetActive(true);
            adButton.DOAnchorPosY(-620, tweenDuration);
        }
        gameOverPanel.SetActive(true);
        GameOverTitle.DOAnchorPosY(735, tweenDuration);
        restartButton.DOAnchorPosY(-870, tweenDuration);
        score.DOAnchorPos(new Vector2(-240, -504), tweenDuration);
    }

    public void GameOverPanelOutro()
    {
        GameOverTitle.DOAnchorPosY(1000, tweenDuration);
        restartButton.DOAnchorPosY(-1000, tweenDuration);
        score.DOAnchorPos(new Vector2(0, 0), tweenDuration);
        adButton.DOAnchorPosY(-1000, tweenDuration);
    }


}
