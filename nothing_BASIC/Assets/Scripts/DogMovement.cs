using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{

    public float distanceApart = 1f;
    public GameObject dog;
    public GameObject player;
    private Animator animator;
    private float speed;
    Vector3 lastPosition = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
            speed = (dog.transform.position - lastPosition).magnitude;
            animator.SetFloat("Move", speed);
            lastPosition = dog.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, dog.transform.position) > distanceApart) {
            dog.transform.position = Vector3.MoveTowards(dog.transform.position, player.transform.position, .03f);
            dog.transform.LookAt(player.transform.position);
        }
        
    }
}
