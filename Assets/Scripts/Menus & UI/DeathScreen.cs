using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        if (Player.GetComponent<Health>().currentHealth <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
