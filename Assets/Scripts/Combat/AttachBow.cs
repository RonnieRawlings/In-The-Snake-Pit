using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachBow : MonoBehaviour
{

    public GameObject sword;
    public GameObject bow;
    public Animator playerAnim;

    private void Update()
    {
        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("bow") == true)
        {
            sword.SetActive(false);
        }
        else if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("bow") == false)
        {
            sword.SetActive(true);
        }
    }
}
