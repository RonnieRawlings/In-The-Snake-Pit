using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class timer : MonoBehaviour
{
    public Text txt;
    public float alertTime=5;
    public GameObject upgradeScreen;
    public GameObject damageButton;
    public GameObject audioManager;
    public GameObject soundManager;

    public float countdown;
    public float currentTime;
    bool hasTriggered = false;
    public int waveCounter; // Counts how many waves have passed.

    public Animator surviveAnim;

    public Text waveCounterText;

    private void Start()
    {
        //txt.text = "0";
        upgradeScreen.SetActive(false);
        //Time.timeScale = 0;
        currentTime = countdown;
        surviveAnim.SetTrigger("WaveStart");
        waveCounter = 1;

        Time.timeScale = 1;
    }
    private void Update()
    {
        //currentTime += Time.deltaTime;
        currentTime -= Time.deltaTime;

        if (waveCounter == 6)
        {
            SceneManager.LoadScene("WinScreen");
        }

        txt.text = ((int)currentTime+1).ToString();
        //if (currentTime>=alertTime && hasTriggered==false)
        if (currentTime <= 0 && hasTriggered == false)
        {
            waveCounter += 1;
            Pause();
            hasTriggered = true;
            //do our thing......
            upgradeScreen.SetActive(true);
            audioManager.GetComponent<AudioManager>().sounds[0].source.Stop();
            audioManager.GetComponent<AudioManager>().sounds[1].source.Stop();
            audioManager.GetComponent<AudioManager>().sounds[2].source.Stop();
            soundManager.GetComponent<SoundManager>().sounds[8].source.Stop();
            soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[9].name);
            audioManager.GetComponent<AudioManager>().Play("UpgradeMenu"); //deactivates battle music and arena sounds and replaces them with sounds and music for the upgrade screen
        }

        waveCounterText.text = "WAVE " + waveCounter.ToString() + "/5"; //Displays current wave on the wave count text UI
    }
    public void ResetTimer()
    {
        hasTriggered = false;
        currentTime = countdown;       
    }
    public void SetWaveLength(int time)
    {
        countdown = time;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
}
