using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorldPlatform(Vector3 position, Item item)
    {
        Transform transform_platform = Instantiate(ItemAssets.Instance.Platform, position, Quaternion.identity);

        ItemWorld itemWorld = transform_platform.GetComponent<ItemWorld>();
        itemWorld.SetItemPlatform(item);
        
        return itemWorld;
    }

    public static ItemWorld SpawnItemWorldJumpPad(Vector3 position, Item item)
    {
        Transform transform_jumpPad = Instantiate(ItemAssets.Instance.JumpPad, position, Quaternion.identity);

        ItemWorld itemWorld = transform_jumpPad.GetComponent<ItemWorld>();
        itemWorld.SetItemJumpPad(item);

        return itemWorld;
    }

    public static ItemWorld SpawnItemWorldCrate(Vector3 position, Item item)
    {
        Transform transform_crate = Instantiate(ItemAssets.Instance.Crate, position, Quaternion.identity);

        ItemWorld itemWorld = transform_crate.GetComponent<ItemWorld>();
        itemWorld.SetItemCrate(item);

        return itemWorld;
    }

    private Item item;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItemPlatform(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public void SetItemJumpPad(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public void SetItemCrate(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
