// Author - Ronnie Rawlings

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerBow : MonoBehaviour
{
    public GameObject arrowProjectile; // Gets access to arrow obj.
    private Vector3 startPos; // Position arrow should start at.

    public SoundManager soundManager;

    private int objMoveSpeed = 150, maxDistance = 1500; // Speed arrow moves & max distence it can.
    private int yOffset = 8, otherOffset = 5; // Positional offsets.
    public int distanceTravled; // Current arrow distence traveled.

    private bool coroutineCalled = false; // Used to prevent multiple coroutines.

    public int fireCount;
    public MeshRenderer bowTarget;
    public Animator playerAnim;

    /// <summary> method <c>CreateArrow</c> Creates new arrow obj & adds needed components to it. </summary>
    public void CreateArrow()
    {        
        BoxCollider arrowCollider = arrowProjectile.GetComponent<BoxCollider>(); // Accesses BoxCollider componet, needed for size change.
        arrowCollider.size = arrowCollider.size * 2; // Doubles collider size. 
        
        arrowProjectile.AddComponent<ArrowTrigger>(); // Adds needed script to arrow obj.
    }

    /// <summary> method <c>KeepPosition</c> Moves arrow obj to behind player obj. </summary>
    public void KeepPosition()
    {
        arrowProjectile.transform.rotation = transform.rotation;
        startPos = new Vector3(transform.position.x, transform.position.y + 7, transform.position.z); // Gets the current player position.
        arrowProjectile.transform.position = startPos; // Moves arrow obj to new position.        
    }

    /// <summary> interface <c>MoveProjectile</c> Moves the arrow obj a set distence, direction depends on facing direction. </summary>
    IEnumerator MoveProjectile()
    {
        coroutineCalled = true; // Prevents multiple coroutines from starting.
        arrowProjectile.transform.parent = null;
        arrowProjectile.transform.GetComponent<BoxCollider>().isTrigger = true; // Sets arrow collider to trigger.
        arrowProjectile.transform.GetComponent<MeshRenderer>().enabled = true;
        fireCount += 1; // counts how many times the player has fired the bow for use in the tutorial.

        // Checks for arrow distence traveled, ends if reached maxDistence.
        while (distanceTravled < maxDistance)
        {
            arrowProjectile.transform.position += arrowProjectile.transform.up * Time.deltaTime * objMoveSpeed; // Moves arrow direction facing.
            yield return new WaitForEndOfFrame(); // Pauses action until frame end.
            distanceTravled += 5; // Increases distence traveled.
        }

        distanceTravled = 0; // Resets traveled distence.

        yield return new WaitForEndOfFrame(); // Pauses action until frame end.
        arrowProjectile.transform.GetComponent<BoxCollider>().isTrigger = false; // Stops arrow collider from being a trigger.     
        arrowProjectile.transform.parent = gameObject.transform;
        arrowProjectile.transform.localPosition = new Vector3(0, 1, 0);
        arrowProjectile.transform.localRotation = Quaternion.Euler(90, 0, 0);
        arrowProjectile.transform.GetComponent<MeshRenderer>().enabled = false;
        coroutineCalled = false; // Allows a new coroutine to begin.
    }

    public void DisableCollisionBox()
    {
        arrowProjectile.GetComponent<BoxCollider>().enabled = false;
    }

    // Called once before first update.
    private void Start()
    {
        startPos = new Vector3(transform.position.x + otherOffset, yOffset, 
            transform.position.z + otherOffset); // Position arrow starts.
        CreateArrow(); // Calls method, creates arrow obj.
    }

    // Called once every frame.
    private void Update()
    {
        // If coroutine hasn't been called, move arrow begind player.
        if (!coroutineCalled)
        {
            DisableCollisionBox();
            //KeepPosition(); // Calls method, keeps arrow behind player.
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetButtonDown("Jump") && !coroutineCalled)
        {
            bowTarget.enabled = true;
            playerAnim.Play("bow");
            playerAnim.Play("Bowmove");
        }

        // Checks whether bow has been shot.
        if (Input.GetKeyUp(KeyCode.Mouse1) || Input.GetButtonUp("Jump") && !coroutineCalled)
        {
            bowTarget.enabled = false;
            soundManager.Play(soundManager.sounds[17].name);
            arrowProjectile.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(MoveProjectile()); // Starts coroutine, moves the arrow facing direction.
        }
    }
}
