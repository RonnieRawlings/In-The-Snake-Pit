// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathing : MonoBehaviour
{
    // Private variables still changable in the inspector.
    [SerializeField]
    private float enemySpeed = 25f; // MoveSpeed of the enemy.
    [SerializeField]
    private int minFollowDistence = 50; // Distence the enemy follows player.
    [SerializeField]
    private int attRange = 1; // Range from the player that allows for attack.
    [SerializeField]
    private float waitTime = 4.0f; // Time between checks.

    private SoundManager soundManager; // Used to find the SoundManager.
    private GameObject player; // Holds Player Obj.
    private Transform playerTransform; // Players XYZ Values.
    private Transform moveSpot; // Random spot enemy moves towards.
    private NavMeshAgent navMeshAgent; // Gets NavMeshAgent comp.

    private float minX, maxX; // X Bounds for enemy movement.
    private float minZ, maxZ; // Z Bounds for enemy movement.
    private int offset = 10; // Map Bounds offset. 
    private int workoutMin = 3; // Allows the MinZ to be found.
    private bool coroutineNotRunning = true; // Makes sure only 1 coroutine is running.
    private bool soundPlaying; // True if sound is playing.

    public Animator playerAnim;

    public float EnemySpeed
    {
        get { return enemySpeed; }
    }

    /// <summary> method <c>PatrolAI</c> Used to start the Patrol Coroutine. </summary>
    public void PatrolAI()
    {
        // Checks wheather a coroutine should be active.
        if (coroutineNotRunning)
        {
            StartCoroutine(WaitTime()); // Starts the patrol coroutine.
        }     
    }

    /// <summary> method <c>SetBorderValues</c> Sets map bounds for enemy movement. </summary>
    public void SetBorderValues()
    {
        SpawnEnemies getSpawnerPos = GameObject.Find("MasterSpawner").GetComponent<SpawnEnemies>(); // Finds spawner positions.

        // Sets each needed min/max bound value.
        minX = getSpawnerPos.spawnerPos[0].x + offset;
        maxX = getSpawnerPos.spawnerPos[2].x - offset;
        minZ = getSpawnerPos.spawnerPos[1].z - (getSpawnerPos.spawnerPos[1].z * workoutMin);
        maxZ = getSpawnerPos.spawnerPos[1].z - offset;
    }

    IEnumerator WaitTime()
    {
        coroutineNotRunning = false; // Stops other coroutines from starting.
        yield return new WaitForSeconds(waitTime); // Waits a specifed time.

        // Moves enemy while not within players area.
        while (Vector3.Distance(transform.position, moveSpot.position) >= 3f)
        {
            navMeshAgent.destination = moveSpot.position * Time.deltaTime;
            yield return new WaitForFixedUpdate(); // Wais until fixed frame ends.
        }

        moveSpot.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ)); // Sets new random moveSpot pos.
        coroutineNotRunning = true; // Allows new coroutine to begin.
    }

    // Called just before Start.
    private void OnEnable()
    {
        SetBorderValues(); // Calls method, sets map bounds.
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>(); // Finds sound manager obj.
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemySpeed;
    }

    // Called when obj is removed from scene.
    private void OnDestroy()
    {
        // Destorys the related movespot, stops obj clutter.
        if (moveSpot.gameObject != null) { Destroy(moveSpot.gameObject); }         
    }

    /// <summary> interface <c>PlayerHitSound</c> Plays sfx when an attack is landed. </summary>
    IEnumerator PlayerHitSound()
    {
        soundPlaying = true; // Prevents overlapping sfx.
        soundManager.Play(soundManager.sounds[Random.Range(12, 15)].name); // Plays related sfx.
        yield return new WaitForSeconds(1.5f); // Waits a specified time.
        soundPlaying = false; // Allows a new sound to play is needed.
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); // Finds player obj.
        playerTransform = player.transform; // Gets the players transform component.

        moveSpot = new GameObject("Point").transform; // Creates new moveSpot obj.
        moveSpot.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ)); // Gets first rand enemy moveSpot.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerAnim.Play("walk2");
        // Moves the enemy towards the player according to their pos & Time.Scale/enemySpeed.
        navMeshAgent.destination = playerTransform.position;

        // If the distence between player & enemy is within attRange, hit the player.
        if (Vector3.Distance(transform.position, playerTransform.position) <= attRange)
        {
            EnemyAttack enemyAttack = transform.GetComponent<EnemyAttack>(); // Accesses enemy attack component.
            enemyAttack.Attack(); // Calls attack method.

            // Checks if sound is playing.
            if (soundPlaying == false)
            {
                StartCoroutine(PlayerHitSound()); // Calls coroutine, plays hit sfx.
            }
        }
    }   
}
