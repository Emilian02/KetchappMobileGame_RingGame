using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    [SerializeField] GameObject scoreTextPrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int randValue = Random.Range(1, 6);
            FindAnyObjectByType<UIScore>().DiamondIncrement(randValue);
            GameObject popUp = Instantiate(scoreTextPrefab, gameObject.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = "+" + randValue.ToString();

            Destroy(gameObject);
        }
    }
}
