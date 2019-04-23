using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowExpanded : MonoBehaviour
{
    private bool arrowLeft = true;
    GameObject inventory;
    GameObject expandedInventory;
    Inventory inventoryComponent;
    public void Start()
    {
        inventory = GameObject.Find("Inventory");
        expandedInventory = GameObject.Find("ExpandedInventory");
        inventoryComponent = inventory.GetComponent<Inventory>();
        expandedInventory.SetActive(false);
    }
    public void ShowExpandedInventory()
    {
        RectTransform showExpandedButtonTransform = GetComponent<RectTransform>();
        if (arrowLeft)
        {
            inventory.SetActive(false);
            expandedInventory.SetActive(true);
            arrowLeft = false;
            showExpandedButtonTransform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else
        {
            inventory.SetActive(true);
            expandedInventory.SetActive(false);
            arrowLeft = true;
            showExpandedButtonTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
