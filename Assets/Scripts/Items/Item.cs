using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        JumpPad,
        Platform,
        Crate
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Platform:
                return ItemAssets.Instance.platformSprite;
            case ItemType.JumpPad:
                return ItemAssets.Instance.jumpPadSprite;
            case ItemType.Crate:
                return ItemAssets.Instance.crateSprite;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Platform:
                return ItemAssets.Instance.platformSprite;
            case ItemType.JumpPad:
                return ItemAssets.Instance.jumpPadSprite;
            case ItemType.Crate:
                return ItemAssets.Instance.crateSprite;
        }
    }
}
