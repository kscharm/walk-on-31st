using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private Rigidbody rbody;
    private AudioSource footsteps;
    public AudioClip singleFootstep;
    public AudioClip singleFootstepRunning;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (rbody.velocity.magnitude > 2.5f && !footsteps.isPlaying) {
            footsteps.clip = singleFootstepRunning;
            footsteps.Play();
        } else if (rbody.velocity.magnitude > 0 && !footsteps.isPlaying) {
            footsteps.clip = singleFootstep;
            footsteps.Play();
        }

    }
}
