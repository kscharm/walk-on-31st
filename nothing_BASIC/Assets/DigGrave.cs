using UnityEngine;

public class DigGrave : MonoBehaviour
{
    bool objectMoving = false;
    public int direction = 0;
    public Condition condition;
    public float speed;
    public float scaleOffset;
    public Vector3 moveTarget;
    private Transform dirtPile;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position + moveTarget;
        dirtPile = GameObject.Find("Pile O' Dirt").transform;
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
            // Grave moving up
            if (direction == 1)
            {
                targetPos = transform.position + moveTarget;
                direction = 0;
                // Decrease size of dirt pile
                dirtPile.localScale += new Vector3(0, -scaleOffset, 0);
                dirtPile.position += new Vector3(0, -scaleOffset / 2.5f, 0);
            }
            // Grave moving down
            else if (direction == 0)
            {
                targetPos = transform.position - moveTarget;
                direction = 1;
                // Increase side of dirt pile
                dirtPile.localScale += new Vector3(0, scaleOffset, 0);
                dirtPile.position += new Vector3(0, scaleOffset / 2.5f , 0);
            } 
            objectMoving = false;
        }
    }
}
