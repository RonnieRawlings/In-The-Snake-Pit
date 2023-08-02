using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodVFXEnemy : MonoBehaviour
{
    public GameObject bloodVFX;
    private void OnTriggerEnter(Collider other)
    {
        Vector3 enemyPos = other.transform.position;
        enemyPos.y = enemyPos.y * 2;

        Quaternion enemyRot = other.transform.rotation;
        enemyRot.y = enemyRot.y * 2;

        if (other.CompareTag("PlayerWeapon"))
        {
            Instantiate(bloodVFX, enemyPos, enemyRot);
        }
    }
}
