﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public const int numItemSlots = 15;
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];

    public void AddItem(Item itemToAdd)
    {
        //First, remove an exisiting fish if we are adding one
        if (itemToAdd.name == "GreenFish" || itemToAdd.name == "BlueFish" || itemToAdd.name == "RedFish" || itemToAdd.name == "YellowFish" || itemToAdd.name == "PurpleFish") {
            RemoveFish();
        }
        //Now add item
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
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

}
