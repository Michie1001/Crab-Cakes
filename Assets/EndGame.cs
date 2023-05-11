using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class EndGame : MonoBehaviour
{
    public GameObject endText;
    public GameObject counts;

    void OnTriggerEnter()
    {
        counts.SetActive(false);
        endText.SetActive(true);
        StartCoroutine(ChottoMatte());
    }

    IEnumerator ChottoMatte()
    {
        yield return new WaitForSeconds(5);
        //Debug.log("Quit game");
        UnityEngine.Application.Quit();
    }
}
