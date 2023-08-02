using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class DashMeter : MonoBehaviour
{
    public Animator Anim;
    public Text number;
    public GameObject player;
    private int dashAmount;
    public void Update()
    {
        dashAmount = player.GetComponent<TopDownMovement>().currentDash;
        number.text = dashAmount.ToString();
        if (dashAmount < 3)
        {
            Anim.SetBool("Bool", true);
        }
        else
        {
            Anim.SetBool("Bool", false);
        }
    }
}
