// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestoryEnemies : MonoBehaviour
{
    private float roundTimer;
    public GameObject bloodVFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pit") && other.isTrigger == true)
        {
            gameObject.GetComponent<Health>().currentHealth -= 100;
            bloodVFX = Resources.Load("VFX/Prefabs/Blood_ VFX_Burst") as GameObject;

            Vector3 enemyPos = other.transform.position;
            enemyPos.y = enemyPos.y * 2;

            Quaternion enemyRot = other.transform.rotation;
            enemyRot.y = enemyRot.y * 2;

            Instantiate(bloodVFX, enemyPos, enemyRot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Prevents tutorial level enemy errors.
        if (SceneManager.GetActiveScene().name == "Tutorial") { return; }

        roundTimer = GameObject.Find("UICanvas").GetComponent<timer>().currentTime; // Finds the roundTimer.

        if (roundTimer <= 0)
        {
           Destroy(gameObject);
        }
    }
}
