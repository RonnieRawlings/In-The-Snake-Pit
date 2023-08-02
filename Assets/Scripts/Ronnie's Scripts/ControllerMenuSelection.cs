// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerMenuSelection : MonoBehaviour
{
    public GameObject mainMenu; // Holds MainMenu Canvas Obj.

    /// <summary> method <c>ChangeMenu</c> Changes which button starts selected on current menu. </summary>
    public void ChangeMenu(GameObject changeMenu)
    {
        EventSystem.current.SetSelectedGameObject(null); // Makes sure the EventSystem currently selected is empty.
        EventSystem.current.SetSelectedGameObject(changeMenu); // Sets currently selected button.
    }

    private void OnEnable()
    {
        ChangeMenu(mainMenu);
    }
}
