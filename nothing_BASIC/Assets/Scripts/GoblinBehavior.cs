using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehavior : MonoBehaviour
{
    private Animator anim;
    public GameObject goblin;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void victoryCheer() {
        anim.SetInteger("moving", 6);
    }

    public void hitPlayer() {
        goblin.transform.LookAt(player.transform);
        anim.SetInteger("moving", 3);
    }

    public void resetToIdle() {
        anim.SetInteger("moving", 0);
    }

}
