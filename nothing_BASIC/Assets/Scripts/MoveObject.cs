using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    bool objectMoving = false;
    public Vector3 moveTarget;
    public float speed;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position + moveTarget;
    }

    void moveObject()
    {
        objectMoving = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (objectMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        if (transform.position == targetPos)
        {
            objectMoving = false;
        }
    }
}
