using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParams : MonoBehaviour
{
    public Animator playerAnim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetButtonDown("Jump"))
        {
            playerAnim.SetBool("swing", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetButtonUp("Jump"))
        {
            playerAnim.SetBool("swing", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetButtonDown("Fire1"))
        {
            playerAnim.SetBool("bow", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetButtonUp("Fire1"))
        {
            playerAnim.SetBool("bow", false);
        }
    }

}
