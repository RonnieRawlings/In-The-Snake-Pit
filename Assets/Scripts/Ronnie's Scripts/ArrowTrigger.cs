// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    public int attDamage = 40; // Bows damage.
    public SoundManager soundManager;

    public void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    /// <summary> method <c>OnTriggerEnter</c> Called whenever arrow collides with any colliders. </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Only checks for enemy collison if arrow should be collidable.
        if (transform.GetComponent<BoxCollider>().isTrigger == true)
        {
            // Checks whether the collision is with an enemy.
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<Health>() == null) { return; }

                soundManager.Play(soundManager.sounds[3].name);
                other.GetComponent<Health>().takeHealth(attDamage); // Removes health from the enemy, half it's health.

                if (other.GetComponent<EnemyAttack>() != null)
                {
                    StartCoroutine(other.GetComponent<EnemyAttack>().KnockBack());
                }
            }
        }     
    }
}
