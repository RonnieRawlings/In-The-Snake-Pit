using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public string CurrentScene;
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(CurrentScene);
        }
    }

}
