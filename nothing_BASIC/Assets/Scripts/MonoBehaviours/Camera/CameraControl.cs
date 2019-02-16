using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool moveCamera = true;                      
    public float smoothing = 7f;
    public Vector3 offset = new Vector3 (0f, 1.5f, 0f); 
    public Transform playerPosition;                    


    private IEnumerator Start ()
    {
        if(!moveCamera)
            yield break;

        yield return null;

        transform.rotation = Quaternion.LookRotation(playerPosition.position - transform.position + offset);
    }


    private void LateUpdate ()
    {
        if (!moveCamera)
            return;

        Quaternion newRotation = Quaternion.LookRotation (playerPosition.position - transform.position + offset);
        transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * smoothing);
    }
}
