using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{

    public float distanceScalar = 0.5f;
    private Vector3 offsetVector;
    public GameObject dog;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, dog.transform.position) > 0.5) {
            
                //**Line below moves dog to behind-right of player. Looks odd when rotating.
            //dog.transform.position = Vector3.MoveTowards(dog.transform.position, player.transform.position + (player.transform.right * distanceScalar) - (player.transform.forward * distanceScalar), 0.02f);

            dog.transform.position = Vector3.MoveTowards(dog.transform.position, player.transform.position, .02f);
        }
        
    }
}
