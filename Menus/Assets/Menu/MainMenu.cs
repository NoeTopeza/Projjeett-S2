using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameM&K");
    }

    public void Quitgame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
