using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliders : MonoBehaviour
{
    public GameObject audioManager;
    public GameObject soundManager;
    public Slider music;
    public Slider sfx;

    public void ChangeMusic()
    {
        audioManager.GetComponent<AudioSource>().volume = music.value;
    }

    public void ChangeSound()
    {
        soundManager.GetComponent<AudioSource>().volume = sfx.value;
    }
}
