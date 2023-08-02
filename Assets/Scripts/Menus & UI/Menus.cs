using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("BUILD (DO NOT TOUCH)");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("BUILD (DO NOT TOUCH)");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
