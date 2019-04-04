using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (rbody.velocity.magnitude > 1f && !GetComponent<AudioSource>().isPlaying) {
            GetComponent<AudioSource>().Play();
        }
    }
}
