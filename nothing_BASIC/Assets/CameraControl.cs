using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;



public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;
    public float moveSpeed;
    public Transform player;

    private Vector3 cursorPosition;
    private bool playerRotating;
    private Quaternion startingRotation;
    private Vector3 startingPosition;

    void Start()
    {
        startingRotation = transform.rotation;
        startingPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerRotating = true;
        } else if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
            playerRotating = false;
        }

        if (playerRotating)
        {
            //transform.Rotate(new Vector3(-1 * Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")));
            transform.RotateAround(player.position, player.transform.up, rotateSpeed * Input.GetAxis("Mouse X"));
            transform.RotateAround(player.position, player.transform.right, rotateSpeed * -1 * Input.GetAxis("Mouse Y"));
            
        } else
        {
            Quaternion currentRotation = Quaternion.RotateTowards(transform.rotation, startingRotation, Time.deltaTime * rotateSpeed);
            transform.rotation = currentRotation;
            Vector3 currentPosition = Vector3.MoveTowards(transform.position, startingPosition, Time.deltaTime * moveSpeed);
            transform.position = currentPosition;
        }

    }

}
