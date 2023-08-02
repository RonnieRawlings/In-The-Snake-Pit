using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    [SerializeField] private Animator animController;
    public string boolName;
    public Collider col;
    public bool keyPress;
    public GameObject soundManager;

    private void Start()
    {
        col.enabled = false;
        soundManager = GameObject.Find("SoundManager");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButton("Fire1"))
        {
            keyPress = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (keyPress == true)
        {
            animController.SetBool(boolName, true);
            StartCoroutine(Wait());
        }

    }

    IEnumerator Wait()
    {
        soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[10].name);
        keyPress = false;
        col.enabled = true;
        yield return new WaitForSeconds(2);
        animController.SetBool(boolName, false);
        yield return new WaitForSeconds(1);
        col.enabled = false;
    }
}
