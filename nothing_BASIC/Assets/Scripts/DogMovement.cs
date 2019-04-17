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
    public Condition[] conditions;
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

        if (timer - hintTime > 10 || state == DogState.Hint && Input.GetKeyDown("n"))
        {
            state = DogState.Follow;
        }
        if (state == DogState.Follow && Input.GetKeyDown("h"))
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
                for (int x = 0; x < conditions.Length; x++)
                {
                    if (!conditions[x].satisfied)
                    {
                        target = hintLoc[x].transform.position;
                        break;
                    }
                }
                break;
        }
        target = new Vector3(target.x, player.transform.position.y, target.z);
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