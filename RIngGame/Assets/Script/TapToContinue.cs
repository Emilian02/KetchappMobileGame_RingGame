using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TapToContinue : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameManager gm;
    void Start()
    {
        
    }

    void Update()
    {
        if(!player.canContinue)
        {
            if (Input.touchCount > 0)
            {
                player.canContinue = true;
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                gm.GameOver = false;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
