// Author = Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOthers : MonoBehaviour
{
    /// <summary> method <c>JustPause</c> Changes the timeScale to 0, freezing all physics objs. </summary>
    public void JustPause()
    {
        Time.timeScale = 0f; // Time is paused for all physics based objects. 
    }

    /// <summary> method <c>JustResume</c> Resets timeScale to 1, unfreezing all physics objs. </summary>
    public void JustResume()
    {
        Time.timeScale = 1f; // Resets the time scale to 1, unpausing the game.
    }

    // OnEnable is called once before Start.
    private void OnEnable()
    {
        JustPause(); // Calls method, pauses the game.
    }
}
