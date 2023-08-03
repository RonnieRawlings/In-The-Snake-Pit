// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class RandLayout : MonoBehaviour
{
    private List<string> arenaLayouts; // Contains all layout names.
    public List<GameObject> arenaLayoutsObj = new List<GameObject>(); // Public var which should contain all arena layout objs.
    public Unity.AI.Navigation.NavMeshSurface navMeshSurface;

    private int randomLayout; // Used to chose the random layout from a list.
    private bool coroutineRunning = false, layoutRemoved = false; // Stops multiple coroutines from running togeather.
    public float roundTimer; // Gets remaning time in round.
    private GameObject currentLayout;

    public TopDownMovement playerMovement; // Gets players movement script.

    [SerializeField] GameObject powerUpPanel;
    
    /// <summary> method <c>PickLayoutObj</c> Randomly selects a layout obj to be used. </summary>
    public void PickLayoutPrefab()
    {
        // Chooses random layout, instantiates it into the arena.
        randomLayout = Random.Range(0, arenaLayouts.Count);
        var loadPrefab = Resources.Load("Prefabs/Layouts/" + arenaLayouts[randomLayout]) as GameObject;
        currentLayout = GameObject.Instantiate(loadPrefab, loadPrefab.transform.position, loadPrefab.transform.rotation);

        // Updates the navmesh area around new layout + updates player spawn.
        playerMovement.SetSpawn();
        navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);        
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

    /// <summary> method <c>RemoveLayout</c> Finds & removes the current layout from the scene, useful for changing layouts between waves. </summary>
    public void RemoveLayout()
    {
        int actualLayout = randomLayout + 1; // randomLayout is the index, this finds the actual.
        Destroy(GameObject.Find("Layout " + actualLayout.ToString() + "(Clone)")); // Removes current layout.
    }

    // Called before Start.
    private void OnEnable()
    {
        // Adds all layouts to list + loads one into the arena.
        arenaLayouts = new List<string>() { "Layout 1", "Layout 2", "Layout 3", "Layout 4", "Layout 5", "Layout 6",
            "Layout 7", "Layout 8", "Layout 9", "Layout 10"};
        PickLayoutPrefab();
    }
}
