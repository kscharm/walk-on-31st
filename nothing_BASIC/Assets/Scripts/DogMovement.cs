using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DogMovement : MonoBehaviour
{

    public float distanceApart;
    public GameObject dog;
    public GameObject player;
    private Animator animator;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(player.transform.position, dog.transform.position) < distanceApart) {
            agent.Stop();
            animator.SetFloat("Move", 0);
        } else {
            agent.Resume();
            animator.SetFloat("Move", 1);
        }
        dog.transform.LookAt(player.transform.position);
    }
}