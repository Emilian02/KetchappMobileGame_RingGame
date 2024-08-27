using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float heightThreshold;
    [SerializeField] float followSpeed = 5.0f;

    void Update()
    {
        Vector3 playerPosition = player.position;

        float targetY = transform.position.y;
        if (Mathf.Abs(playerPosition.y - transform.position.y) > heightThreshold)
        {
            targetY = playerPosition.y;
        }

        Vector3 targetPosition = new Vector3(playerPosition.x + 1.5f, targetY, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
