using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic3 : MonoBehaviour
{
    public GameObject audioManager;

    private void Start()
    {
        audioManager.GetComponent<AudioManager>().Play("LoseMenu");
    }
}
