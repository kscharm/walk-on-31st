using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Level0_Guy_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private NavMeshAgent agent;
    private Animator animator;
    private bool moving = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            animator.SetTrigger(1);
            agent.SetDestination(player.transform.position);

            if (Vector3.Distance(agent.transform.position, player.transform.position) > .5) {
                animator.SetFloat("Speed", 1);
            } else {
                animator.SetFloat("Speed", 0);
            }
        }
        
    }

    void makeWalk()
    {
        animator.SetTrigger(1);
        moving = true;
    }
}
