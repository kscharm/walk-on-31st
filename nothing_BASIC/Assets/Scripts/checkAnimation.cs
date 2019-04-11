using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError(animator.GetCurrentAnimatorStateInfo(0).IsName("fridge"));
    }
}
