using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemContainer;
    private Transform SlotImage;

    public static UI_Inventory instance;

    public GameObject itemImage;

    private void Awake()
    {
        itemContainer = transform.Find("itemContainer");
        instance = this;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        UpdateInventoryItem();
    }

    public void UpdateInventoryItem()
    {
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }
        
        
        foreach (Item item in inventory.GetItemList())
        {
            UI_Item uiItem = Instantiate(itemImage, itemContainer).GetComponent<UI_Item>();
            uiItem.gameObject.SetActive(true);
            uiItem.itemImage.sprite = item.GetSprite();
            uiItem.itemType = item.itemType;
            uiItem.item = item;

            if(item.amount > 1)
            {
                uiItem.tmp.SetText(item.amount.ToString());
            }
            else
            {
                uiItem.tmp.SetText("");
            }    
        }
    }
}
