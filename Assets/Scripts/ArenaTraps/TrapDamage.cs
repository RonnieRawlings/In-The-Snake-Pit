using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public Collider col;
    public GameObject soundManager, bloodVFX;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().currentHealth -= 25;
            StartCoroutine(Col());
        }
        else if (other.CompareTag("Enemy"))
        {
            bloodVFX = Resources.Load("VFX/Prefabs/Blood_ VFX_Burst") as GameObject;
            Vector3 trapPos = other.transform.position;
            trapPos.y = trapPos.y * 2;

            Instantiate(bloodVFX, trapPos, transform.rotation);

            soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[3].name);
            Destroy(other.gameObject.transform.GetChild(2).gameObject);
            Destroy(other.gameObject);           
        }
    }
    IEnumerator Col()
    {
        col.enabled = true;
        yield return new WaitForSeconds(0.1f);
        col.enabled = false;
        yield return new WaitForSeconds(2);
        col.enabled = true;
    }
}
