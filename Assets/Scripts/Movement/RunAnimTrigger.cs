using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimTrigger : MonoBehaviour
{
    public Animator runAnim;
    public bool KeyPress;

    public void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            runAnim.Play("walk2");
        }
    }
}
