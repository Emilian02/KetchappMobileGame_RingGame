using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().GameOver = true;
            FindAnyObjectByType<UIAnimation>().GameOverPanelIntro();
            FindAnyObjectByType<Player>().SetLastPipe(gameObject);
        }
    }
}
