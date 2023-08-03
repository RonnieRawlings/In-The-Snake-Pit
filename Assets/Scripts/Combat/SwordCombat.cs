using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordCombat : MonoBehaviour
{
    public Animator attackAnim;
    public bool KeyPress;
    public Collider col;
    public GameObject soundManager;
    public int crystalCount;

    private bool coroutinePlaying = false;
    private int timesPlayed = 0;

    public int attackDamage = 50;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButton("Fire1"))
        {
            KeyPress = true;
            if (coroutinePlaying == false)
            {
                StartCoroutine(Swing());
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            KeyPress = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<Health>() == null) { return; }

            other.GetComponent<Health>().takeHealth(attackDamage);
            soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[3].name);

            if (other.GetComponent<EnemyAttack>() != null)
            {
                StartCoroutine(other.GetComponent<EnemyAttack>().KnockBack());
            }           
        }

        if (other.CompareTag("Health"))
        {
            Debug.Log("health detected");
            Destroy(other.gameObject);
            GetComponentInParent<Health>().currentHealth += 25;
            soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[16].name);
            if (GetComponentInParent<Health>().currentHealth > GetComponentInParent<Health>().baseHealth)
            {
                GetComponentInParent<Health>().currentHealth = GetComponentInParent<Health>().baseHealth;
            }
            crystalCount += 1;
        }
    }

    IEnumerator Swing()
    {
        coroutinePlaying = true;
        if (KeyPress == true)
        {
            col.enabled = true;
            attackAnim.Play("swing");
            if (timesPlayed < 1)
            {
                soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[Random.Range(0, 2)].name);
                timesPlayed += 1;
            }
        }
        yield return new WaitForSeconds(0.5f);
        col.enabled = false;
        yield return new WaitForSeconds(0.5f);
        coroutinePlaying = false;
        timesPlayed = 0;
    }
}

    