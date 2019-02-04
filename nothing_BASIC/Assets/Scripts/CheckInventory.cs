using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckInventory : MonoBehaviour
{
    public List<string> itemsToCheck;
    public UnityEvent OnHasItems = new UnityEvent();
    public PlayerInventory inventoryToCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkInventory()
    {
        bool hasItems = true;
        foreach(string item in itemsToCheck)
        {
            if (!inventoryToCheck.inventory.Contains(item))
            {
                hasItems = false;
            }
        }
        if (hasItems)
        {
            print("invoking");
            OnHasItems.Invoke();
        }
    }


}
