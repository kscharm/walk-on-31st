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
    Inventory expandedInventoryComponent;
    Item[] items;
    public Image[] itemImages;
    public void Start()
    {
        inventory = GameObject.Find("Inventory");
        expandedInventory = GameObject.Find("ExpandedInventory");
        expandedInventoryComponent = expandedInventory.GetComponent<Inventory>();
        inventoryComponent = inventory.GetComponent<Inventory>();
        items = inventoryComponent.items;
        expandedInventory.SetActive(false);
    }
    public void ShowExpandedInventory()
    {
        RectTransform showExpandedButtonTransform = GetComponent<RectTransform>();
        if (arrowLeft)
        {
            // Add items in invetory to expanded inventory for visualization purposes
            // Clear all inventory cells
            expandedInventoryComponent.items = new Item[Inventory.numItemSlots];
            // Add all inventory items, otherwise clear the cell
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    expandedInventoryComponent.AddItem(items[i]);
                } else
                {
                    expandedInventoryComponent.itemImages[i].sprite = null;
                    expandedInventoryComponent.itemImages[i].enabled = false;
                }
            }
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
