using UnityEngine;

public class DigGrave : MonoBehaviour
{
    bool objectMoving = false;
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
        if (condition.satisfied)
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
        }
        if (transform.position == targetPos)
        {
            objectMoving = false;
        }
    }
}
