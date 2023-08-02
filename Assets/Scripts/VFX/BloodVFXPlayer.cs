using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVFXPlayer : MonoBehaviour
{
    public GameObject bloodVFX;
    private void OnTriggerEnter(Collider other)
    {
        Vector3 playerPos = other.transform.position;
        playerPos.y = playerPos.y * 2;

        Quaternion playerRot = other.transform.rotation;
        playerRot.y = playerRot.y * 2;

        if (other.CompareTag("EnemyWeapon"))
        {
            Instantiate(bloodVFX, playerPos, playerRot);
        }
    }
}
