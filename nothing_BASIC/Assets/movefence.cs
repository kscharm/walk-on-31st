﻿using UnityEngine;

public class Movefence : MonoBehaviour
{
    bool objectMoving = false;
    public Condition condition;
    public float speed;
    Vector3 targetPos;
    private bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
    	targetPos = transform.position + new Vector3(0,0,1);
    }

    public void moveObject()
    {
        if (condition.satisfied && !moved);
        {
            objectMoving = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (objectMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            moved = true;
            objectMoving = false;

        } 

    }
}

