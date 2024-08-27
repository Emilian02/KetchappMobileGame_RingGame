using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pipePrefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnInterval;

    private GameObject lastPipe;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnInterval);
    }

    void SpawnPipe()
    {
        // Randomly select a pipe prefab
        int randomIndex = Random.Range(0, pipePrefabs.Length);
        GameObject selectedPipe = pipePrefabs[randomIndex];

        Vector3 spawnPosition;
        if (lastPipe == null)
        {
            spawnPosition = spawnPoint.position;
        }
        else
        {
            Transform endPoint = lastPipe.transform.Find("EndPoint");
            Transform startPoint = selectedPipe.transform.Find("StartPoint");

            Vector3 offset = startPoint.position - selectedPipe.transform.position;
            spawnPosition = endPoint.position - offset;
        }

        // Spawn the selected pipe
        lastPipe = Instantiate(selectedPipe, spawnPosition, selectedPipe.transform.rotation);
    }
}