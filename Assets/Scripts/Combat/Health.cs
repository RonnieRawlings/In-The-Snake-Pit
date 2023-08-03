//Author: Ran Blake-James
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //public Upgrades Upgrades;
    public float baseHealth;
    public float currentHealth;
    public GameObject item;
    public TextMeshProUGUI healthValueText;
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
        item = gameObject;

        // Only set visual health if item is player.
        if (item.name == "Player")
        {
            healthValueText.text = currentHealth.ToString() + "/" + baseHealth.ToString();
        }              
    }

    public void Update()
    {
        // Destroies obj if health is 0 or less.
        if (currentHealth <= 0)
        {
            GameObject.Find("EventSystem").GetComponent<ThumbConditions>().KillCount += 1;
            Destroy(item);
        }

        // Only updates health visually if player.
        if (item.name != "Enemy")
        {
            healthValueText.text = currentHealth.ToString() + "/" + baseHealth.ToString();
            healthBar.maxValue = baseHealth;
        }
        
        // Enables vignette if health is low enough, ignores if not player.
        if (currentHealth <= 30 && item.name != "Enemy")
        {
            postVolume.enabled = true;
        }
        else if (item.name != "Enemy" && SceneManager.GetActiveScene().name != "Tutorial")
        {
            postVolume.enabled = false;
        }
    }
}
