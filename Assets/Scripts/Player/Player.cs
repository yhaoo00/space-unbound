using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;

    public static Player instance;

    private Inventory inventory;
    public Camera cam;
    public SpriteRenderer currentSprite;
    public Item.ItemType currentItemType;
    public Item currentItem;

    private RaycastHit2D checkOverlap;
    bool playSound = true;

    private void Start()
    {
        instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        uiInventory.UpdateInventoryItem();

        /*
        ItemWorld.SpawnItemWorldPlatform(new Vector3(-5, 0), new Item { itemType = Item.ItemType.Platform, amount = 1 });
        ItemWorld.SpawnItemWorldJumpPad(new Vector3(0, -3.76f), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
        ItemWorld.SpawnItemWorldCrate(new Vector3(-5, 1), new Item { itemType = Item.ItemType.Crate, amount = 1 });*/

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            ItemWorld.SpawnItemWorldPlatform(new Vector3(-5, 0), new Item { itemType = Item.ItemType.Platform, amount = 1 });
        }

        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(-7, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(-6, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(-5, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(-4, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(-3, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(-2, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(-1, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(0, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(7, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(6, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(5, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(4, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(3, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(2, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            ItemWorld.SpawnItemWorldJumpPad(new Vector3(1, -2), new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
        }

        currentSprite.sprite = null;
    }

    void Update()
    {
        Vector3 position = cam.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        currentSprite.transform.position = position;

        Vector2 v2Position = (Vector2)position;
        Vector2 platformSize = ItemAssets.Instance.GetSizePlatform();
        Vector2 jumpPadSize = ItemAssets.Instance.GetSizeJumpPad();
        Vector2 crateSize = ItemAssets.Instance.GetSizeCrate();

        if (currentSprite.sprite != null && Input.GetMouseButtonDown(0))
        {
            SoundManager.PlaySound("drop");
            if (currentItemType == Item.ItemType.Platform)
            {
                checkOverlap = Physics2D.BoxCast(v2Position, platformSize, 0, Vector2.zero, 0f);
                if (checkOverlap)
                { 
                    currentItem.amount += 1;
                    uiInventory.UpdateInventoryItem();

                    if (currentItem.amount <= 1)
                    {
                        Inventory.instance.AddItem(currentItem);
                    }
                }
                else ItemWorld.SpawnItemWorldPlatform(position, new Item { itemType = Item.ItemType.Platform, amount = 1 });
            }

            if (currentItemType == Item.ItemType.JumpPad)
            {
                checkOverlap = Physics2D.BoxCast(v2Position, jumpPadSize, 0, Vector2.zero, 0f);
                if (checkOverlap)
                {
                    currentItem.amount += 1;
                    uiInventory.UpdateInventoryItem();

                    if (currentItem.amount <= 1)
                    {
                        Inventory.instance.AddItem(currentItem);
                    }
                }
                else ItemWorld.SpawnItemWorldJumpPad(position, new Item { itemType = Item.ItemType.JumpPad, amount = 1 });
            }

            if (currentItemType == Item.ItemType.Crate)
            {
                checkOverlap = Physics2D.BoxCast(v2Position, crateSize, 0, Vector2.zero, 0f);
                if (checkOverlap) 
                {
                    currentItem.amount += 1;
                    uiInventory.UpdateInventoryItem();

                    if (currentItem.amount <= 1)
                    {
                        Inventory.instance.AddItem(currentItem);
                    }
                }
                else ItemWorld.SpawnItemWorldCrate(position, new Item { itemType = Item.ItemType.Crate, amount = 1 });
            }
            currentSprite.sprite = null;
        }

        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            PlayWinSFX();
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
        }
    }

    void PlayWinSFX()
    {
        if (playSound) SoundManager.PlaySound("win");

        playSound = false;
    }
}
