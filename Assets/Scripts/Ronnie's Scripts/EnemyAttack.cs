// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    // Fields changeable in the inspector, testing purposes.
    [SerializeField]
    public Transform attPoint; // A point out from the object, where the attack starts.
    [SerializeField]
    public LayerMask enemies; // Layer the object can detect for the attack.
    public Health target; // Player health.

    private float attRange = 100f; // How far the overlap field extends.
    private bool coroutineNotStarted = true; // Makes sure only 1 coroutine is running.
    private int knockBackStart = 0, knockBackEnd = 22; // How far knockback goes.
    
    public GameObject soundManager; // Holds SoundManger Obj.
    
    /// <summary> method <c>Attack</c> Allows all enemy sprites to detect & inflict damage to the player. </summary>
    public void Attack()
    {
        // A SpheareCollider is sent out using attRange & stores the objects collided with.
        Collider[] enemiesHit = Physics.OverlapSphere(attPoint.position, attRange, enemies);

        // Removes every object previously collided with from the scene.
        foreach (Collider enemy in enemiesHit)
        {
            // Checks if coroutine is already running.
            if (coroutineNotStarted)
            {
                StartCoroutine(WaitForSeconds()); // Starts the coroutine for taking health.
            }                    
        }
    }

    /// <summary> interface <c>KnockBack</c> Moves the enemy back quickly, creates a knockback effect. </summary>
    public IEnumerator KnockBack() 
    {
        float moveSpeed = transform.GetComponent<EnemyPathing>().EnemySpeed * 8; // Speed at which enemy moves backward.
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        // Enemy will move backward until knockBackEnd.
        while (knockBackStart != knockBackEnd)
        {
            
            transform.position += -transform.forward * Time.deltaTime * moveSpeed; // Moves enemy back.
            yield return new WaitForEndOfFrame(); // Waits until frame end to loop again.

            knockBackStart += 1; // Adds 1 to knockback count time.
        }

        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        knockBackStart = 0;
    }

    /// <summary> interface <c>WaitForSeconds</c> Takes health away from , plays sfx, waits after to stop overlapping attack/sound </summary>
    IEnumerator WaitForSeconds()
    {
        coroutineNotStarted = false; // Stops more coroutines from being called.

        target.takeHealth(15); // Removes health from player.
        soundManager.GetComponent<SoundManager>().Play(soundManager.GetComponent<SoundManager>().sounds
            [Random.Range(12, 14)].name); // Plays related sfx.

        yield return new WaitForSeconds(2.0f); // Waits before allowing another attack to begin.
        coroutineNotStarted = true; // Allows new coroutine to begin.
    }

    // Start is called before the first frame update
    void Start()
    {
       target = GameObject.Find("Player").transform.GetComponent<Health>(); // Finds player & gets related health component.
    }
}
