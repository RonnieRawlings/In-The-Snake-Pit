using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HpBar;
    public GameObject player;
    public Text number;

    void Update()
    {
        float Health = player.GetComponent<Health>().currentHealth;

        HpBar.SetValueWithoutNotify(Health);

        //number.text = Health.ToString();
    }
}
