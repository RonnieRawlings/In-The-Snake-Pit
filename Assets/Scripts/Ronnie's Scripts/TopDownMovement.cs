// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public int dashLimit; // Max dashes the player can have.
    public int currentDash; // Currently available dashes.
    public float moveSpeed; // Speed the player moves.
    public Animator runAnim; // Animator for the player

    private CharacterController movement; // Holds the CharacterController componet.
    private int moveOffset = 12; // Top gate player pushback.
    private float gravity = 0.5f; // Gravity which affects the player.
    private float verticalSpeed = 0; // Speed at which the player desends.
    private bool routineCalled = false; // Prevents multiple coroutines from running at once.
    private Vector3 spawnPos = new Vector3(55.76f, 7.49f, -58.5f); // Spawn XYZ.
    private Vector3 teleportLeft = new Vector3(126.89f, 3, -24.0f); // Left Teleport Position.
    private Vector3 teleportRight = new Vector3(-19.32f, 3, -24.0f); // Right Teleport Position.
    public int timesDashed;

    public SoundManager soundManager;
    public int trapsTriggered;

    /// <summary> method <c>OnTriggerEnter</c> Teleports player to new position when entering a teleport wall. </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Checks which teleport wall has been entered.
        if (other.CompareTag("WallLeft"))
        {
            movement.enabled = false; // Disables CharacterController.
            movement.transform.position = teleportLeft; // Moves player to other gate.
            movement.enabled = true; // Re-enables CharacterController.
        }
        else if (other.CompareTag("WallRight"))
        {
            movement.enabled = false; // Disables CharacterController.
            movement.transform.position = teleportRight; // Moves player to other gate.
            movement.enabled = true; // Re-enables CharacterController.
        }
        else if (other.CompareTag("TopWall"))
        {
            movement.enabled = false; // Disables CharacterController.
            movement.transform.position = new Vector3(transform.position.x, transform.position.y, 
                transform.position.z - moveOffset); // Stops player entering the top gate.
            movement.enabled = true; // Re-enables CharacterController.
        }
    }

    /// <summary> method <c>SetSpawn</c> Moves the player to the set spawn location. </summary>
    public void SetSpawn()
    {
        movement.enabled = false; // Deactives CharacterController, to set new transform.
        movement.transform.position = spawnPos; // Sets transform to spawnPos.
        movement.enabled = true; // Re-enables the CharacterController.
    }

    /// <summary> method <c>Movement</c> Gives the playerObject movement according to button presses & adds gravity. </summary>
    public void Movement()
    {              
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 
            Input.GetAxis("Vertical")); // Uses the set axis to decide which way the player moves.

        movement.Move(move * moveSpeed * Time.deltaTime); // Moves the player at a fixed time & according to moveSpeed.

        // As long as the player is moving this activates.
        if (move != Vector3.zero)
        {
            runAnim.Play("walk2");
            gameObject.transform.forward = move; // Sets forward to transform to move.
        }

        verticalSpeed -= gravity * Time.deltaTime; // Sets gravity.
        move.y = verticalSpeed; // Moves the player down according to gravity.
        movement.Move(move); // Moves the player.

        // Resets gravity whenever onGround.
        if (movement.isGrounded && move.y <= 0)
        {
            verticalSpeed = 0; // Resets gravity.
        }
    }

    /// <summary> method <c>Dash</c> Allows player to dash across the arena at a much faster than normal move speed. </summary>
    public void Dash()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0,
            Input.GetAxis("Vertical")); // Grants access to both movement axis.

        // Checks if key is pressed & a dash is available.
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Fire2") && currentDash != 0)
        {           
            movement.Move(move * 8); // Uses the CharacterController to preform the dash.
            currentDash--; // Removes a dash from the player.
            soundManager.Play(soundManager.sounds[15].name);
            timesDashed += 1;
        }
        // If the Coroutine isn't running, this starts it.
        else if (routineCalled == false)
        {            
            StartCoroutine(DashRecharge()); // Starts a Coroutine to increase currentDash.
        }
    }

    /// <summary> interface <c>DashRecharge</c> When dash is below the limit, this function waits a 
    /// specified time before increasing the amount of dashes available. </summary>
    IEnumerator DashRecharge()
    {     
        routineCalled = true; // Makes sure a new Coroutine isn't started while this one runs.

        // Runs while the player has less dashes than the limit.
        while (currentDash < dashLimit)
        {
            // If an error occurs & current dash > the limit, set currentDash back to the limit.
            if (currentDash > dashLimit)
            {
                currentDash = dashLimit; // Sets dash to max.
            }
            // Increase the amount of available dashes after waiting a specified time.
            else if (currentDash < dashLimit)
            {
                yield return new WaitForSeconds(3); // Wait specified time.
                currentDash++; // Gives player another dash.
                break; // Breaks out of while loop.
            }
            // Once currentDash is equal to the dashLimit, break the loop.
            else if (currentDash == dashLimit)
            {
                break; // Breaks out of while loop.
            }
        }
       
        routineCalled = false; // Once the Coroutine is finished, another one may start.     
        yield break; // Ends the Coroutine.
    }

    // OnEnable is called just before Start.
    private void OnEnable()
    {
        movement = GetComponent<CharacterController>(); // Gets access to CharController, allows movement.
        SetSpawn(); // Calls method, sets players spawn.
    }

    // Start is called before the first frame update
    void Start()
    {          
        currentDash = dashLimit; // Starts available dashes to max on start.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement(); // Calls method, moves the player.
    }

    // Called Each Frame.
    private void Update()
    {
        Dash(); // Calls method, checks dash count & allows player to dash.
    }
}
