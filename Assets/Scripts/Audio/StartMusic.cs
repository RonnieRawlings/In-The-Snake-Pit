using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public GameObject audioManager;

    private void Start()
    {
        audioManager.GetComponent<AudioManager>().Play("MainMenu");
    }
}
