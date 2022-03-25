using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void Awake()
    {
        
    }

    void OnMouseOver()
    {
        ItemWorld itemWorld = GetComponent<ItemWorld>();
        if(Input.GetMouseButtonDown(1))
        {
            SoundManager.PlaySound("pickup");
            
            Inventory.instance.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
