using System.Collections;
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
    public GameObject gameOverMessage;
    public Condition toThrowCondition;
    public Transform throwFrom;
    public ReactionCollection sceneReset;
    public GameObject ragdoll;
    public GameObject bodyForce;


    // private double maxInteractionDistance = 1.5;
    // private float ikWeight = 0;

    private Rigidbody rbody;
    private Inventory inventory;



    private Interactable currentInteractable;
    private Vector3 destinationPosition;
    private bool handleInput = true;
    private WaitForSeconds inputHoldWait;
    private readonly int hashLocomotionTag = Animator.StringToHash("Locomotion");


    public const string startingPositionKey = "starting position";


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
        inventory = FindObjectOfType<Inventory>();


    }


    private void OnAnimatorMove()
    {
        // Still necessary despite being empty
    }


    private void Update()
    {
        movePlayer(); // WASD movement
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

        if (Input.GetKey("left shift"))
        {
            rbody.velocity *= 2;
        }
        if (Input.GetKey("a") || Input.GetKey("d")) {
            if (Input.GetKey("left shift")) {
                // Fast turn
                if (Input.GetKey("a")) {
                    transform.Rotate(new Vector3(0, (float)(-1 * rotateSpeed * 1.5 * Time.deltaTime), 0));
                } else {
                    transform.Rotate(new Vector3(0, (float)(rotateSpeed * 1.5 * Time.deltaTime), 0));
                }
            } else {
                // Regular turn
                if (Input.GetKey("a")) {
                    transform.Rotate(new Vector3(0, -1 * rotateSpeed * Time.deltaTime, 0));
                }
                else {
                    transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
                }
            }
        }

        //Set animation 
        if (Input.GetKey("left shift") && rbody.velocity != Vector3.zero) {
            animator.SetFloat("Speed", 5);
        } else if (Vector3.Distance(Vector3.zero, rbody.velocity) != 0) {
            animator.SetFloat("Speed", 2);
        } else if (Input.GetKey("d") || Input.GetKey("a")){ 
            animator.SetFloat("Speed", 1);
        } else {
            animator.SetFloat("Speed", 0);
        }
        
    }

    private void throwBottle()
    {
        if (toThrowCondition.satisfied == true)
        {
            animator.SetTrigger("HighTake");
            GameObject bottle = Instantiate(throwingBottle, throwFrom.position, new Quaternion()) as GameObject;
            bottle.GetComponent<Rigidbody>().AddForce(new Vector3(0, throwUpForce, 0));
            bottle.GetComponent<Rigidbody>().AddForce((throwTo.transform.position - bottle.transform.position) * throwForceScale);
            bottle.GetComponent<Rigidbody>().AddTorque(throwSpin);
        }
    }

    private void disableCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
        


    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "enemy")
       {
            hitFrom(other.transform);
            
       }
       if (other.tag == "red carpet")
       {
            SceneManager.LoadScene("YouWon", LoadSceneMode.Single);
       }
    }

    public void hitFrom(Transform hit)
    {
        animator.enabled = false;
        ragdoll.SetActive(true);
        GetComponent<CapsuleCollider>().enabled = false;
        bodyForce.GetComponent<Rigidbody>().AddForce(Vector3.up * 3000);
        bodyForce.GetComponent<Rigidbody>().AddForce((transform.position - hit.position) * 4000);
        Global.time -= 20;
        //sceneReset.React();
    }

}
