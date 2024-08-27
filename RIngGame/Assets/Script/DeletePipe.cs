using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePipe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pipe"))
        {
            Destroy(collision.gameObject);
        }
    }
}
