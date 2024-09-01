using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] pipePrefabs;
    [SerializeField] GameObject diamond;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnInterval;
    [SerializeField] float diamondSpawnChance;
    [SerializeField] GameManager gm;
    [SerializeField] int mirrorInterval = 10;
    [SerializeField] TextMeshProUGUI mirrorWarningText;

    private GameObject lastPipe;
    int pipeCounter = 0;
    int mirrorCounter = 0;
    float randomEvent;

    void Start()
    {
        InvokeRepeating("SpawnPipe", 1f, spawnInterval);
    }

    void SpawnPipe()
    {
        if(gm.GameOver)
        {
            return;
        }

        // Randomly select a pipe prefab
        int randomIndex = Random.Range(0, pipePrefabs.Length);
        GameObject selectedPipe = pipePrefabs[randomIndex];

        Vector3 spawnPosition;
        if (lastPipe == null)
        {
            spawnPosition = spawnPoint.position;
            selectedPipe = pipePrefabs[0];
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

        pipeCounter++;
        mirrorCounter++;

        if (mirrorCounter == mirrorInterval - 1)
        {
            randomEvent = Random.value;
            if (randomEvent < 0.8f) 
            {
                StartCoroutine(MirrorWarningCoroutine());
            }
            else 
            {
                StartCoroutine(UpsideDownWarningCoroutine());
            }
        }

        if (pipeCounter >= 2)
        {
            pipeCounter = 0;
            if (Random.value < diamondSpawnChance)
            {
                Vector3 diamondPosition = new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, spawnPosition.z);
                Instantiate(diamond, diamondPosition, Quaternion.identity);
            }
        }
    }
    void MirrorScreen()
    {
        Matrix4x4 mat = Camera.main.projectionMatrix;

        mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));

        Camera.main.projectionMatrix = mat;
    }

    void UpsideDown()
    {
        Matrix4x4 mat = Camera.main.projectionMatrix;

        mat *= Matrix4x4.Scale(new Vector3(1, -1, 1));

        Camera.main.projectionMatrix = mat;
    }

    IEnumerator MirrorWarningCoroutine()
    {
        mirrorWarningText.gameObject.SetActive(true);
        for (int i = 5; i > 0; i--)
        {
            mirrorWarningText.text = "!!!Mirroring in " + i + " seconds!!!";
            yield return new WaitForSeconds(1f);
        }

        mirrorWarningText.gameObject.SetActive(false);
        MirrorScreen();
        mirrorCounter = 0;
    }

    IEnumerator UpsideDownWarningCoroutine()
    {
        mirrorWarningText.gameObject.SetActive(true);
        for (int i = 5; i > 0; i--)
        {
            mirrorWarningText.text = "!!!Upside Down in " + i + " seconds!!!";
            yield return new WaitForSeconds(1f);
        }

        mirrorWarningText.gameObject.SetActive(false);
        UpsideDown();
        mirrorCounter = 0;
    }
}
