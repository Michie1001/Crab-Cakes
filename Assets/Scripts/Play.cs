using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    private int scene = 0;
    public void OnClick()
    {
        PlayGame();
    }
    void PlayGame()
    {
        SceneManager.LoadScene(scene + 1);
    }
}
