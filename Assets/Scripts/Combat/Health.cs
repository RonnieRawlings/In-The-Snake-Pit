//Author: Ran Blake-James
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine;

public class Health : MonoBehaviour
{
    //public Upgrades Upgrades;
    public float baseHealth;
    public float currentHealth;
    public GameObject item;
    public Text healthValueText;
    public Slider healthBar;

    public Volume postVolume;

    public float getHealth()
    {
        return currentHealth;
    }

    public void giveHealth(float helf)
    {
        helf = helf + currentHealth;
        if (helf > baseHealth)
        {
            currentHealth = baseHealth;
        }
        else
        {
            currentHealth = helf;
        }
    }
    public void resetHealth()
    {
        currentHealth = baseHealth;
    }
    public void takeHealth(float helf)
    {
        helf = currentHealth - helf;
        if (helf < 0)
        {
            helf = 0;
        }
        currentHealth = helf;
    }

    // Start is called before the first frame update
    public void Start()
    {
        resetHealth();
        healthValueText.text = currentHealth.ToString() + "/" + baseHealth.ToString();
    }
    public void Update()
    {
        if (currentHealth <= 0)
        {
            GameObject.Find("EventSystem").GetComponent<ThumbConditions>().KillCount += 1;
            Destroy(item);
        }
        //baseHealth = Upgrades.Health;
        healthValueText.text = currentHealth.ToString() + "/" + baseHealth.ToString();

        healthBar.maxValue = baseHealth;

        if (currentHealth <= 30)
        {
            postVolume.enabled = true;
        }
        else
        {
            postVolume.enabled = false;
        }
    }
}
