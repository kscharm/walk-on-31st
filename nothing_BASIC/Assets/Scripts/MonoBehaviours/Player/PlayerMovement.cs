using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public SaveData playerSaveData;
    public float turnSmoothing = 15f;
    public float speedDampTime = 0.1f;
    public float slowingSpeed = 0.175f;
    public float turnSpeedThreshold = 0.5f;
    public float inputHoldDelay = 0.5f;
    private double maxInteractionDistance = 1.5;
    private float ikWeight = 0;
    private float rotateSpeed = 1f;
    Vector3 direction;
    Quaternion rotatePlayer;
    private Rigidbody rbody;
    bool holdingSkey = false;
    

    private Interactable currentInteractable;
    private Vector3 destinationPosition;
    private bool handleInput = true;
    private WaitForSeconds inputHoldWait;


    private readonly int hashSpeedPara = Animator.StringToHash("Speed");
    private readonly int hashLocomotionTag = Animator.StringToHash("Locomotion");


    public const string startingPositionKey = "starting position";


    private const float stopDistanceProportion = 0.1f;
    private const float navMeshSampleDistance = 4f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();

        agent.updateRotation = false;

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
        agent.velocity = animator.deltaPosition / Time.deltaTime;
    }


    private void Update()
    {
        if (agent.pathPending)
            return;

        float speed = agent.desiredVelocity.magnitude;
        
        if (agent.remainingDistance <= agent.stoppingDistance * stopDistanceProportion)
            Stopping (out speed);
        else if (agent.remainingDistance <= agent.stoppingDistance)
            Slowing(out speed, agent.remainingDistance);
        else if (speed > turnSpeedThreshold)
            Moving ();
        
        animator.SetFloat(hashSpeedPara, speed, speedDampTime, Time.deltaTime);
        movePlayer(); //WASD movement
    }


    private void Stopping (out float speed)
    {
        agent.Stop();

        transform.position = destinationPosition;
        speed = 0f;

        if (currentInteractable)
        {
            transform.rotation = currentInteractable.interactionLocation.rotation;
            currentInteractable.Interact();
            currentInteractable = null;

            StartCoroutine (WaitForInteraction ());
        }
    }


    private void Slowing (out float speed, float distanceToDestination)
    {
        agent.Stop();

        float proportionalDistance = 1f - distanceToDestination / agent.stoppingDistance;

        Quaternion targetRotation = currentInteractable ? currentInteractable.interactionLocation.rotation : transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, proportionalDistance);

        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, slowingSpeed * Time.deltaTime);

        speed = Mathf.Lerp(slowingSpeed, 0f, proportionalDistance);
    }


    private void Moving ()
    {
        Quaternion targetRotation = Quaternion.LookRotation(agent.desiredVelocity);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSmoothing * Time.deltaTime);
    }


    // public void OnGroundClick(BaseEventData data)
    // {
    //     if(!handleInput)
    //         return;
        
    //     currentInteractable = null;

    //     PointerEventData pData = (PointerEventData)data;

    //     NavMeshHit hit;
    //     if (NavMesh.SamplePosition (pData.pointerCurrentRaycast.worldPosition, out hit, navMeshSampleDistance, NavMesh.AllAreas))
    //         destinationPosition = hit.position;
    //     else
    //         destinationPosition = pData.pointerCurrentRaycast.worldPosition;

    //     agent.SetDestination(destinationPosition);
    //     agent.Resume ();
    // }


    public void OnInteractableClick(Interactable interactable)
    {
        if(!handleInput)
            return;

        currentInteractable = interactable;
        destinationPosition = currentInteractable.interactionLocation.position;

        agent.SetDestination(destinationPosition);
        agent.Resume();
        

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
        agent.Resume();

        if (Input.GetKey("w")) {
            agent.SetDestination(agent.transform.position + agent.transform.forward.normalized);

        }
        if (Input.GetKey("s")) {
            holdingSkey = true;
            rbody.MovePosition(rbody.position - (rbody.transform.forward.normalized * 0.07f));
            agent.transform.position = rbody.transform.position;
        } else { //Called when done hitting the 's' key
            if (holdingSkey) {
                agent.SetDestination(agent.transform.position);
                holdingSkey = false;
            }
        }
        if (Input.GetKey("d")) {
            direction = agent.transform.right.normalized;
            rotatePlayer = Quaternion.LookRotation(direction);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotatePlayer, Time.deltaTime * rotateSpeed);

        }
        if (Input.GetKey ("a")) {
            direction = -agent.transform.right.normalized;
            rotatePlayer = Quaternion.LookRotation(direction);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotatePlayer, Time.deltaTime * rotateSpeed);
        }
        if (agent.remainingDistance < 0.5f) {
            agent.Stop();
        }

    }

         private void rotateTowards(Transform target) {
            Vector3 direction = (target.position - agent.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
     }
}
