// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool gamePaused = false; // Allows for a pause check to be made.
  
    /// <summary> method <c>PauseGame</c> Sets the TimeScale to 0, effectivly pausing the game.</summary>
    public void PauseGame()
    {
        Time.timeScale = 0f; // Time is paused for all physics based objects. 
        ActivateChildren(); // Calls a method to activate the pause menu.
        gamePaused = true; // Tells script game is paused.
    }

    /// <summary> method <c>ResumeGame</c> Sets the TimeScale back to 1, effectivly un-pausing the game &
    /// allowing all frozen objects to move again.</summary>
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resets the time scale to 1, unpausing the game.
        DeactivateChildren(); // Calls a method to deactivate the pause menu.
        gamePaused = false; // Tells script the game has resumed.
    }

    /// <summary> method <c>DeactivateChildren</c> Stops the pause menu from being shown in the scene when 
    /// the game isn't paused, this is done by deactivating the canvas & all of it's children.</summary>
    public void DeactivateChildren()
    {
        // Loops through every child of the current object, deactivating them.
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false); // Sets current obj to inactive.
        }
    }

    /// <summary> metthod <c>ActivateChildren</c> Once the scene is paused, this method reactivates the 
    /// previously deactivated children.</summary>
    public void ActivateChildren()
    {
        // Loops through every child of the current gameObject, reactivating them.
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true); // Activates current obj.
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DeactivateChildren(); // Deactives pause screen until needed.
    }

    // Update is called once per frame
    void Update()
    {
        // If the escape key is pressed the game is either paused or unpaused.
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetButtonUp("Fire3"))
        {
            // Depending on the variable state, the game is paused or unpaused.
            if (gamePaused)
            {
                ResumeGame(); // Calls method, resets time scale.
            }
            else
            {
                PauseGame(); // Calls method, changes time scale to 0.
            }
        }
    }
}
