using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform Platform;
    public Transform JumpPad;
    public Transform Crate;

    public Sprite platformSprite;
    public Sprite jumpPadSprite;
    public Sprite crateSprite;

    public Vector2 GetSizePlatform()
    {
        //return (Vector2)Platform.localScale;
        return new Vector2(3, .5f);
    }

    public Vector2 GetSizeJumpPad()
    {
        return (Vector2)JumpPad.localScale;
    }

    public Vector2 GetSizeCrate()
    {
        return (Vector2)Crate.localScale;
    }
}
