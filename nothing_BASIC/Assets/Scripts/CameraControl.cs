using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;



public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;
    public Transform player;
    public float XRotMax;
    public float XRotMin;

    private Vector3 cursorPosition;
    private bool playerRotating;
    private Quaternion startingRotation;
    private Vector3 startingPosition;

    void Start()
    {
        startingRotation = transform.localRotation;
        startingPosition = transform.localPosition;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startingRotation = transform.localRotation;
            startingPosition = transform.localPosition;

            Cursor.lockState = CursorLockMode.Locked;
            playerRotating = true;
        } else if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
            playerRotating = false;
        }

        if (playerRotating)
        {
            transform.RotateAround(player.position, player.transform.up, rotateSpeed * Input.GetAxis("Mouse X"));
            float xAngle = transform.rotation.eulerAngles.x;
            if (xAngle > 180) xAngle -= 360;
            if (!(xAngle > XRotMax & Input.GetAxis("Mouse Y") <= 0) & !(xAngle < XRotMin & Input.GetAxis("Mouse Y") >= 0))

            {
                transform.RotateAround(player.position, transform.right, rotateSpeed * -1 * Input.GetAxis("Mouse Y"));
            }
            
        } else
        {
        }


    }

}
