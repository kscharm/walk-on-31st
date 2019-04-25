using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Level0_Guy_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject ragdoll;
    public GameObject key2;

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
        float dist = Vector3.Distance(player.transform.position, agent.transform.position);
        if (dist < 15)
        {
            moving = true;
        }
        if (moving)
        {
            agent.SetDestination(player.transform.position);

            if (Vector3.Distance(agent.transform.position, player.transform.position) > 1) {
                animator.SetFloat("Speed", 0.75f);
            } else {
                animator.SetFloat("Speed", 0);
            }
        }
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "throwable")
        {
            key2.transform.position = agent.transform.position;
            key2.SetActive(true);
            animator.enabled = false;
            ragdoll.SetActive(true);
            GetComponent<CapsuleCollider>().enabled = false;
            agent.Stop();
        }
    }
}
