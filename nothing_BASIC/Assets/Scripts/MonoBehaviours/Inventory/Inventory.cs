using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public const int numItemSlots = 15;
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    private GameObject expandedInventory;
    private Inventory inventoryComponent;
    private Inventory expandedInventoryComponent;

    public void Start()
    {
        expandedInventory = GameObject.Find("ExpandedInventory");
        expandedInventoryComponent = expandedInventory.GetComponent<Inventory>();
    }

    public void AddItem(Item itemToAdd)
    {
        //First, remove an exisiting fish or sauce if we are adding one
        if (itemToAdd.name == "GreenFish" || itemToAdd.name == "BlueFish" || itemToAdd.name == "RedFish" || itemToAdd.name == "YellowFish" || itemToAdd.name == "PurpleFish") {
            RemoveFish();
        } if (itemToAdd.name == "RedSauce" || itemToAdd.name == "GreenSauce" || itemToAdd.name == "OrangeSauce" || itemToAdd.name == "BlueSauce" || itemToAdd.name == "PinkSauce") {
            RemoveSauce();
        }
        //Now add item
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                expandedInventoryComponent.items[i] = itemToAdd;
                expandedInventoryComponent.itemImages[i].sprite = itemToAdd.sprite;
                expandedInventoryComponent.itemImages[i].enabled = true;
                return;
            } 
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                expandedInventoryComponent.items[i] = null;
                expandedInventoryComponent.itemImages[i].sprite = null;
                expandedInventoryComponent.itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void RemoveFish() {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] != null && (items[i].name == "GreenFish" || items[i].name == "YellowFish" || items[i].name == "RedFish" || items[i].name == "BlueFish" || items[i].name == "PurpleFish")) {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public void RemoveSauce() {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] != null && (items[i].name == "RedSauce" || items[i].name == "GreenSauce" || items[i].name == "OrangeSauce" || items[i].name == "BlueSauce" || items[i].name == "PinkSauce")) {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    

}
