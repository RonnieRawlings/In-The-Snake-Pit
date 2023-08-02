// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SpawnEnemies : MonoBehaviour
{
    // All fields that should be visible in the Inspector.
    [SerializeField]
    private List<string> spawners = new List<string>(); // A list of the spawner names.
    [SerializeField]
    private int spawnLimit = 1; // How many enemies can be spawned at one time.
    [SerializeField]
    private int gravity = 50; // How gravity effects enemies.

    private GameObject enemy; // Holds enemy obj.
    private GameObject enemyParent; // Holds enemies parent obj.
    private int waveCounter;

    public List<Vector3> spawnerPos = new List<Vector3>(); // A list of the spawner world positions.
    public float currentTime; // Current deltaTime.
    public float waveEnd = 120; // How long the wave lasts.   

    /// <summary> method <c>CreateSpawner</c> Creates/Places a new GameObject in the scene, with the name/position given. </summary>
    public void CreateSpawner(string objName, Vector3 position)
    {
        GameObject newSpawner = new GameObject(objName); // Creates a new spawner obj in scene.
        newSpawner.transform.position = position; // Moves spawner obj to specified pos.
    }

    /// <summary> method <c>CreateEnemy</c> Loads enemy model into scene at the given pos as a child of the spawner, 
    /// also adds the needed componants. </summary>
    public void CreateEnemy(string spawnName, Vector3 enemyPos)
    {       
        enemyParent = GameObject.Find(spawnName); // Finds the specified spawner.

        var loadPrefab = Resources.Load("Prefabs/Enemy") as GameObject; // Loads enemy model from prefab.
        enemy = GameObject.Instantiate(loadPrefab, transform.position = enemyPos, transform.rotation); // Instantiates enemy model into current scene.

        Rigidbody enemyRB = enemy.GetComponent<Rigidbody>(); // Accesses rigidbody component in enemy.
        enemyRB.AddForce(Vector3.down * gravity * enemyRB.mass); // Adds gravitational force to the enemy.

        enemy.name = "Enemy"; // Changes enemy obj name.
        enemy.layer = 6; // Changes obj layer, allows obj to interact with specifc things.

        enemy.transform.SetParent(enemyParent.transform); // Moves enemy to spawner, gives impresion they spawn there.
        enemy.GetComponent<EnemyFacing>().target = GameObject.Find("Player").transform; // Gives the enemy a target to attack/follow.       

        Attacking(enemy); // Calls the attack method.
    }

    /// <summary> method <c>Attacking</c> Takes the given GameObject & gives it the EnemyAttack script as a component. </summary>
    public void Attacking(GameObject enemy)
    {
        enemy.AddComponent<EnemyAttack>(); // Adds EnemyAttack Script to obj, allow enemy to interact with player.
        EnemyAttack enemyAttackComp = enemy.GetComponent<EnemyAttack>(); // Gives easy access to enemyAttack component.

        enemyAttackComp.attPoint = enemy.transform.GetChild(0).transform; // Sets attackPoint pos.
        enemyAttackComp.enemies = LayerMask.GetMask("Player"); // Makes sure enemy can only attack player.
    }

    /// <summary> interface <c>WaitForSeconds</c> Waits between each enemey spawned. </summary>
    IEnumerator WaitForSeconds(string currentSpawner, Vector3 spawnerPos)
    {
       // 6-10, 5-7, 4-6, 2-5, 1-3
            
        // While time is left in the round, enemies spawn.
        while (spawnLimit == 1)
        {
            if (waveCounter == 1)
            {
                yield return new WaitForSeconds(Random.Range(7, 11));
                CreateEnemy(currentSpawner, spawnerPos);
            }
            else if (waveCounter == 2)
            {
                yield return new WaitForSeconds(Random.Range(6, 8));
                CreateEnemy(currentSpawner, spawnerPos);
            }
            else if (waveCounter == 3)
            {
                yield return new WaitForSeconds(Random.Range(5, 7));
                CreateEnemy(currentSpawner, spawnerPos);
            }
            else if (waveCounter == 4)
            {
                yield return new WaitForSeconds(Random.Range(3, 6));
                CreateEnemy(currentSpawner, spawnerPos);
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(1, 3));
                CreateEnemy(currentSpawner, spawnerPos);
            }
        }                 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.deltaTime; // Accesses current deltaTime.

        // Allows for enemies to be spawned, according to specified timing.
        for (int x = 0; x < spawners.Count; x++)
        {
            CreateSpawner(spawners[x], spawnerPos[x]); // Creates new spawner at specified pos.
            StartCoroutine(WaitForSeconds(spawners[x], spawnerPos[x])); // Starts coroutine which creates enemy objs at spawners.
        }
    }

    private void Update()
    {
        waveCounter = GameObject.Find("UICanvas").GetComponent<timer>().waveCounter; // Finds currentWave.
    }
}
