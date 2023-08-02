using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTrigger : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    public string BoolName;
    public GameObject soundManager;
    public TopDownMovement player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<TopDownMovement>();
        soundManager = GameObject.Find("SoundManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        player.trapsTriggered += 1;
        myAnimationController.SetBool(BoolName, true);
        soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds[11].name);
        yield return new WaitForSeconds(2);
        myAnimationController.SetBool(BoolName, false);
    }
}