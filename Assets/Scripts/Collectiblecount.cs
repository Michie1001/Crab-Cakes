using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Collectiblecount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
    public GameObject endText;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start() => UpdateCount();

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        if(count == Collectible.total)
        {
            endText.SetActive(true);
            StartCoroutine(ChottoMatte());
        }
        else
        {
            count++;
            UpdateCount();
        }
    }

    void UpdateCount()
    {
        text.text = $"{count} / {Collectible.total}";
    }

    IEnumerator ChottoMatte()
    {
        yield return new WaitForSeconds(5);
        //Debug.log("Quit game");
        Application.Quit();
    }
}
