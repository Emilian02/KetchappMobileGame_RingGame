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
    [SerializeField]
    float resetYOffset = 1.0f;

    public bool canContinue;
    
    Vector2 currentVelocity;
    GameObject lastPipe;

    void Start()
    {
        rb.bodyType = RigidbodyType2D.Static;
        canContinue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.GameOver)
        {
            rb.bodyType = RigidbodyType2D.Static;
            return;
        }
        if (gm.Playing && canContinue)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    FindAnyObjectByType<UIScore>().IncrementScore();
                    rb.AddForce(jumpForce);
                    SpeedController();
                }
            }
        }
        
    }


    public void ResetPlayerPositione()
    {
        if (lastPipe != null)
        {
            // Calculate the new position slightly above the last pipe
            Vector3 pipePosition = lastPipe.transform.position;
            Vector3 newPosition = new Vector3(pipePosition.x, pipePosition.y + resetYOffset, transform.position.z);

            // Reset the player's position
            transform.position = newPosition;
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static; 
        }
    }

    public void SetLastPipe(GameObject pipe)
    {
        lastPipe = pipe;
    }

    void SpeedController()
    {
        currentVelocity = rb.velocity;
        currentVelocity.x = Mathf.Clamp(currentVelocity.x, 2, 2);
        currentVelocity.y = Mathf.Clamp(currentVelocity.y, 0, 2);
        rb.velocity = currentVelocity;
    }
}
