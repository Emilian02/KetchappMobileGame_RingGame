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
    RectTransform startButton;
    [SerializeField]
    float tweenDuration;

    void Start()
    {
        
    }

    public async void StartButton()
    {
        await StartPanelOutro();
        startScreen.SetActive(false);
    }

    async Task StartPanelOutro()
    {
        await title.DOAnchorPosY(750, tweenDuration).AsyncWaitForCompletion();
        await startButton.DOAnchorPosY(-500, tweenDuration).AsyncWaitForCompletion();
    }

}
