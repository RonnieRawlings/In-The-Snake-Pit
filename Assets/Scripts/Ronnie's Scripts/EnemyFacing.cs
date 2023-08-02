// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacing : MonoBehaviour
{
    public Transform target; // Holds Players Transform.
    private float interPol = 1; // Interpolation num.

    /// <summary> method <c>LookAt</c> Rotates the enemy to face the player at all times on the Y axis. </summary>
    public void LookAt()
    {
        Vector3 targetLookAt = target.transform.position - transform.position; // Gets the exact pos to look at.
        targetLookAt.y = transform.position.y; // Gets the specifc Y axis.
        Quaternion actualRotation = Quaternion.LookRotation(targetLookAt); // Sets rotation to a Quaternion.
        transform.rotation = Quaternion.Slerp(transform.rotation, actualRotation, interPol); // Actually changes the roation using Slerp.
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the target is set.
        if (target != null)
        {
            LookAt(); // Calls method, changes the enemies rotation.
        }
    }
}
