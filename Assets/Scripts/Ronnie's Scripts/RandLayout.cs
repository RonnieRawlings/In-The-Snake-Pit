// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class RandLayout : MonoBehaviour
{
    private List<string> arenaLayouts = new List<string>() { "Layout 1", "Layout 2", "Layout 3", "Layout 4", "Layout 5", "Layout 6", 
        "Layout 7", "Layout 8"}; // Contains all layout names.
    public List<GameObject> arenaLayoutsObj = new List<GameObject>(); // Public var which should contain all arena layout objs.
    public NavMeshSurface[] navMeshSurfaces = new NavMeshSurface[7];

    private int randomLayout; // Used to chose the random layout from a list.
    private bool coroutineRunning = false, layoutRemoved = false; // Stops multiple coroutines from running togeather.
    public float roundTimer; // Gets remaning time in round.
    private GameObject currentLayout;

    public TopDownMovement playerMovement; // Gets players movement script.

    /// <summary> method <c>PickLayoutScene</c> Randomly selects a scene which contains a selected layout. </summary>
    public void PickLayoutScene()
    {
        randomLayout = Random.Range(0, 4); // Gens a random number between specified values.
        SceneManager.LoadScene(arenaLayouts[randomLayout]); // Loads specified scene.
    }
    
    /// <summary> method <c>PickLayoutObj</c> Randomly selects a layout obj to be used. </summary>
    public void PickLayoutPrefab()
    {
        randomLayout = Random.Range(0, arenaLayouts.Count); // Gens rand num between 0 & length of given list.
        var loadPrefab = Resources.Load("Prefabs/Layouts/" + arenaLayouts[randomLayout]) as GameObject; // Adds layout obj to scene.
        currentLayout = GameObject.Instantiate(loadPrefab, loadPrefab.transform.position, loadPrefab.transform.rotation); // Instantiates the obj.
    }

    /// <summary> method <c>DeactivateObj</c> Deactivates every layout obj, this stops layout overlapping issues. </summary>
    public void DeactivateObj()
    {
        // Sets all layout objs to inactive.
        foreach (GameObject layout in arenaLayoutsObj)
        {
            layout.SetActive(false); // Sets current obj to inactive.
        }
    }  

    /// <summary> method <c>RemoveLayout</c> Finds & removes the current layout from the scene, useful for 
    /// changing layouts between waves. </summary>
    public void RemoveLayout()
    {
        int actualLayout = randomLayout + 1; // randomLayout is the index, this finds the actual.
        Destroy(GameObject.Find("Layout " + actualLayout.ToString() + "(Clone)")); // Removes current layout.
    }

    /// <summary> interface <c>WaitForSeconds</c> Waits a set time, useful for tesing certain functions. </summary>
    IEnumerator WaitForSeconds()
    {
        // Keeps coroutine running until roundTimer ends.
        while (roundTimer >= 0)
        {            
            yield return new WaitForEndOfFrame(); // Waits until current frame ends.
        }
       
        RemoveLayout(); // Calls this method.
        layoutRemoved = true; // Script now knows layout is gone.        
    }

    // Called before Start.
    private void OnEnable()
    {
        PickLayoutPrefab(); // Calls this method.

        NavMesh.RemoveAllNavMeshData();
        for (int i = 0; i < navMeshSurfaces.Length; i++)
        {
            navMeshSurfaces[i].BuildNavMesh();
        }
    }

    // Called once before first frame.
    private void Start()
    {
        roundTimer = GameObject.Find("UICanvas").GetComponent<timer>().currentTime; // Finds the roundTimer.
        StartCoroutine(WaitForSeconds()); // Starts a coroutine meant to remove the current layout.
    }

    // Called once each frame.
    private void Update()
    {
        roundTimer = GameObject.Find("UICanvas").GetComponent<timer>().currentTime; // Finds the roundTimer.

        // Checks if layout is gone.
        if (layoutRemoved)
        {
            RemoveLayout(); // Makes sure layout is acc gone.
            PickLayoutPrefab(); // Calls method, loads new rand layout.

            NavMesh.RemoveAllNavMeshData();
            navMeshSurfaces[0].BuildNavMesh();

            layoutRemoved = false; // New layout in scene.
            playerMovement.SetSpawn(); // Resets players spawn for new layout.  
            StartCoroutine(WaitForSeconds()); // Calls coroutine, checks when round ends.                 
        }
    }
}
