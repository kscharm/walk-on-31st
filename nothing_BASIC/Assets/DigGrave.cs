using UnityEngine;

public class DigGrave : MonoBehaviour
{
    bool objectMoving = false;
    int direction = 0;
    public Condition condition;
    public float speed;
    Vector3 targetPos;
    public Vector3 moveTarget;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position + moveTarget;
    }

    public void moveObject()
    {
        Debug.Log("Inside function call");
        if (condition.satisfied)
        {
            Debug.Log("Grave moving");
            objectMoving = true;
        }
        
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
            if (direction == 1)
            {
                targetPos = transform.position + moveTarget;
                direction = 0;
            }
            else if (direction == 0)
            {
                targetPos = transform.position - moveTarget;
                direction = 1;
            } 
            objectMoving = false;
        }
    }
}
