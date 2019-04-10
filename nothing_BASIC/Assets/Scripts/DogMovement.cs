using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DogMovement : MonoBehaviour
{

    public enum DogState
    {
        Follow,
        Hint
    };

    public float distanceApart;
    public GameObject dog;
    public GameObject player;
    public GameObject[] hintLoc;
    private Animator animator;
    private NavMeshAgent agent;
    private double timer;
    private double hintTime;
    private DogState state;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = dog.GetComponent<NavMeshAgent>();
        state = DogState.Follow;
        timer = 0;
        hintTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = player.transform.position;
        timer += Time.deltaTime;

        if (timer > hintTime + 15)
        {
            state = DogState.Follow;
        }
        if (timer > hintTime + 30 || Input.GetKeyDown("h"))
        {
            state = DogState.Hint;
            hintTime = timer;
        }

        switch (state)
        {
            case DogState.Follow:
                target = player.transform.position;
                break;

            case DogState.Hint:
                target = hintLoc[Mathf.Min((int)timer / 30, hintLoc.Length - 1)].transform.position;
                break;
        }
        agent.SetDestination(target);

        if (Vector3.Distance(target, dog.transform.position) < distanceApart) {
            agent.Stop();
            animator.SetFloat("Move", 0);
        } else {
            agent.Resume();
            animator.SetFloat("Move", 1);
        }
        dog.transform.LookAt(target);
    }
}