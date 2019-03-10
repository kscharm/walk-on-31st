﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public SaveData playerSaveData;

    public float inputHoldDelay = 0.5f;
    private float playerSpeed = 2f; 
    public float rotateSpeed;
    public float throwForceScale = 1;
    public float throwUpForce = 10;
    public Vector3 throwSpin;
    public GameObject throwingBottle;
    public GameObject throwTo;

    // private double maxInteractionDistance = 1.5;
    // private float ikWeight = 0;

    private Rigidbody rbody;

    

    private Interactable currentInteractable;
    private Vector3 destinationPosition;
    private bool handleInput = true;
    private WaitForSeconds inputHoldWait;
    private readonly int hashLocomotionTag = Animator.StringToHash("Locomotion");


    public const string startingPositionKey = "starting position";


    // private const float stopDistanceProportion = 0.1f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();

        inputHoldWait = new WaitForSeconds (inputHoldDelay);

        string startingPositionName = "";
        playerSaveData.Load(startingPositionKey, ref startingPositionName);
        Transform startingPosition = StartingPosition.FindStartingPosition(startingPositionName);

        transform.position = startingPosition.position;
        transform.rotation = startingPosition.rotation;

        destinationPosition = transform.position;


    }


    private void OnAnimatorMove()
    {
        //Still necessary despite being empty
    }


    private void Update()
    {
        Debug.Log("Yo");
        movePlayer(); //WASD movement
    }

    public void OnInteractableClick(Interactable interactable)
    {
        if(!handleInput)
            return;

        currentInteractable = interactable;
        destinationPosition = currentInteractable.interactionLocation.position;

        if (currentInteractable)
        {
            //transform.rotation = currentInteractable.interactionLocation.rotation;
            //Check distance here!
            currentInteractable.Interact();
            currentInteractable = null;

            StartCoroutine(WaitForInteraction());
        }


        //Needs to only do this if the interactable is collectable
        //if (currentInteractable.interactionLocation.transform.position.y < .2) {
        //    animator.SetBool("LowTake", true);
        //    animator.SetBool("MedTake", false);
        //    animator.SetBool("HighTake", false);
        //} else if (currentInteractable.interactionLocation.transform.position.y < .5) {
        //    animator.SetBool("MedTake", true);
        //    animator.SetBool("LowTake", false);
        //    animator.SetBool("HighTake", false);
        //} else {
        //    animator.SetBool("HighTake", true);
        //    animator.SetBool("MiddleTake", false);
        //    animator.SetBool("LowTake", false);
        //}



    }


    private IEnumerator WaitForInteraction ()
    {
        handleInput = false;

        yield return inputHoldWait;

        while (animator.GetCurrentAnimatorStateInfo(0).tagHash != hashLocomotionTag)
        {
            yield return null;
        }

        handleInput = true;
    }

    /*
    private void OnAnimatorIK() {
        if (agent.velocity == Vector3.zero && System.Math.Abs(agent.transform.position.x - currentInteractable.transform.position.x) < maxInteractionDistance) {
            animator.SetBool("atDestination", true);
            ikWeight = animator.GetFloat("pocketItem");
        } else {
            animator.SetBool("atDestination", false);
            ikWeight = 0;
        }
        
        animator.SetLookAtWeight(ikWeight);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);
        animator.SetLookAtPosition(currentInteractable.transform.position);
        animator.SetIKPosition(AvatarIKGoal.RightHand, currentInteractable.transform.position);
    }*/

    private void movePlayer() {
        if (Input.GetKey("w") || Input.GetKey("s")) {
            if (Input.GetKey("w")) {
                rbody.velocity = transform.forward * playerSpeed;
            } else {
                rbody.velocity = transform.forward * -playerSpeed;
            }
        } else {
            rbody.velocity = Vector3.zero;
        }

        if (Input.GetKey("d")) {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKey ("a")) {
            transform.Rotate(new Vector3(0, -1 * rotateSpeed * Time.deltaTime, 0));
        }

        //Set animation 
        if (Vector3.Distance(Vector3.zero, rbody.velocity) != 0) {
            animator.SetFloat("Speed", 2);
        } else if (Input.GetKey("d") || Input.GetKey("a")){ 
            animator.SetFloat("Speed", 1);
        } else {
            animator.SetFloat("Speed", 0);
        }
        
    }

    private void throwBottle()
    {
        Debug.Log("Throw bottle!");
        GameObject bottle = Instantiate(throwingBottle, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion()) as GameObject;
        bottle.GetComponent<Rigidbody>().AddForce(new Vector3(0, throwUpForce, 0));
        bottle.GetComponent<Rigidbody>().AddForce((throwTo.transform.position - bottle.transform.position) * throwForceScale);
        bottle.GetComponent<Rigidbody>().AddTorque(throwSpin);
    }

}
