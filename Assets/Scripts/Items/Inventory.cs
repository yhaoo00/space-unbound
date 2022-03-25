using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    public static Inventory instance;

    private List<Item> itemList;

    public Inventory()
    {
        instance = this;
        itemList = new List<Item>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //pass
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            AddItem(new Item { itemType = Item.ItemType.Platform, amount = 1 });
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 2 });
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            AddItem(new Item { itemType = Item.ItemType.Platform, amount = 2 });
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 2 });
            AddItem(new Item { itemType = Item.ItemType.Crate, amount = 1 });

        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 4 });
            AddItem(new Item { itemType = Item.ItemType.Crate, amount = 1 });
            AddItem(new Item { itemType = Item.ItemType.Platform, amount = 2 });
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 4 });
            AddItem(new Item { itemType = Item.ItemType.Crate, amount = 1 });

        }

        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 5 });
            AddItem(new Item { itemType = Item.ItemType.Crate, amount = 1 });
            AddItem(new Item { itemType = Item.ItemType.Platform, amount = 5 });
        }

        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 5 });
            AddItem(new Item { itemType = Item.ItemType.Crate, amount = 1 });
        }

        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            //pass
        }
        /*AddItem(new Item { itemType = Item.ItemType.Platform, amount = 3 });
        AddItem(new Item { itemType = Item.ItemType.JumpPad, amount = 3 });
        AddItem(new Item { itemType = Item.ItemType.Crate, amount = 3 });*/
    }

    public void AddItem(Item item)
    {
        bool itemAlreadyInInventory = false;
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            {
                inventoryItem.amount += item.amount;
                itemAlreadyInInventory = true;
            }
        }

        if (!itemAlreadyInInventory)
        {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        Item inventoryItemToRemove = null;
        foreach (Item inventoryItem in itemList)
        {
            if (inventoryItem.itemType == item.itemType)
            { 
                inventoryItem.amount--;
                if (inventoryItem.amount <= 0)
                { 
                    inventoryItemToRemove = item;
                }
                break;
            }
        }
        if (inventoryItemToRemove != null)
        {
            itemList.Remove(inventoryItemToRemove);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
