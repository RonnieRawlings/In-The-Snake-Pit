using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider slider;

    public void MusicVoid()
    {
        GetComponent<AudioSource>().volume = slider.value;
    }



}
