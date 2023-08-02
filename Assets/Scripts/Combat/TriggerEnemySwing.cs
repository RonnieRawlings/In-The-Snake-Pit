using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemySwing : MonoBehaviour
{
    public Animator attackAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            attackAnim.Play("enemyswing");
        }

    }
}
