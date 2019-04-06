using UnityEngine;

public class DigGrave : MonoBehaviour
{
    bool objectMoving = false;
    public int direction = 0;
    public float speed;
    public float scaleOffset;
    public Condition condition;
    public Vector3 moveTarget;
    private GameObject dirtPile;
    private Transform dirtPileTransform;
    Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position + moveTarget;
        dirtPile = GameObject.Find("Pile O' Dirt");
        dirtPileTransform = dirtPile.transform;
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
            moveTarget = -moveTarget;
            targetPos = transform.position + moveTarget;
            // Grave moving up
            if (direction == 1)
            {
                direction = 0;
                // Decrease size of dirt pile
                dirtPileTransform.localScale += new Vector3(0, -scaleOffset, 0);
                dirtPileTransform.position += new Vector3(0, -scaleOffset / 2.5f, 0);
            }
            // Grave moving down
            else
            {
                direction = 1;
                // Increase side of dirt pile
                dirtPileTransform.localScale += new Vector3(0, scaleOffset, 0);
                dirtPileTransform.position += new Vector3(0, scaleOffset / 2.5f , 0);
            } 
            objectMoving = false;
        }
    }
}
