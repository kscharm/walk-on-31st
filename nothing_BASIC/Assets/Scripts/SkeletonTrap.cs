using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonTrap : MonoBehaviour
{
    public GameObject creation;
    public Vector3 spawnLoc;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Instantiate(creation, spawnLoc, new Quaternion(0, 0, 0, 0));
    }
}
