using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    Vector2 jumpForce;
    Vector2 currentVelocity;

    void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.GameOver)
        {
            rb.bodyType = RigidbodyType2D.Static;
            gm.StopScreen = true;
            return;
        }

        if (!gm.StartScreen)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    rb.AddForce(jumpForce);
                    SpeedController();
                }
            }
        }
        
    }

    void SpeedController()
    {
        currentVelocity = rb.velocity;
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, 2, 2);
        currentVelocity.y = Mathf.Clamp(currentVelocity.y, 0, 2);
        rb.velocity = currentVelocity;
    }
}
