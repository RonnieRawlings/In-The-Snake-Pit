using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeDamage : MonoBehaviour
{
    private GameObject bloodVFX;
    public GameObject player;
    public SoundManager soundManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundManager.Play(soundManager.sounds[3].name);
            soundManager.Play(soundManager.sounds[Random.Range(12, 14)].name);
            player.GetComponent<Health>().currentHealth -= 35;
            player.GetComponent<TopDownMovement>().SetSpawn();
        }
        else if (other.CompareTag("Enemy"))
        {
            soundManager.Play(soundManager.sounds[3].name);
            Destroy(other.transform.GetChild(2).gameObject);
            Destroy(other.gameObject);
        }
    }
}
