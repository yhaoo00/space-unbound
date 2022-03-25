using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UI_Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;
    public Item.ItemType itemType;
    public Item item;

    bool inside = false;

    public TextMeshProUGUI tmp;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        inside = true;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        inside = false;
    }
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && inside)
        {
            SoundManager.PlaySound("select");
            
            Player.instance.currentSprite.sprite = Item.GetSprite(itemType);
            Player.instance.currentItemType = itemType;
            Player.instance.currentSprite.enabled = true;
            Player.instance.currentItem = item;

            Inventory.instance.RemoveItem(item);
        }

    }
}