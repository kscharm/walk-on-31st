using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public bool deleteOnPickup = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addToInventory()
    {
        playerInventory.inventory.Add(gameObject.ToString());
        if (deleteOnPickup)
        {
            gameObject.SetActive(false);
        }
    }
}
