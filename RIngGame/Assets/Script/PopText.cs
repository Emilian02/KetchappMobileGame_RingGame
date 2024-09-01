using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopText : MonoBehaviour
{
    [SerializeField] Vector2 initialVelocity;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float timer;
    void Start()
    {
        rb.velocity = initialVelocity;
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
