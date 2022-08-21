using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    private Item inventoryItem;

    public event EventHandler onListChanged;

    public InventoryManager()
    {
        inventoryItem = new Item();
    }

    public void AddItem(Item item)
    {
        inventoryItem = item;
        onListChanged?.Invoke(this, EventArgs.Empty);
    }

    public Item GetItem()
    {
        Debug.Log(inventoryItem.itemType);
        return inventoryItem;
    }
}
