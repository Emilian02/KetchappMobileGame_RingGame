using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] UIAnimation _uiAniamtion;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            _gameManager.StartButton();
            _uiAniamtion.StartButton();
        }
    }
}
