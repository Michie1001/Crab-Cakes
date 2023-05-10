using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    private int scene = 0;
    public void Start()
    {
        StartCoroutine(PlayGame());
    }
    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(scene + 1);
    }
}
