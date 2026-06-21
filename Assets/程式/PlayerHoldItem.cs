using UnityEngine;

public class PlayerHoldItem : MonoBehaviour
{
    public ItemData holdingItem;

    public bool HasItem()
    {
        return holdingItem != null;
    }

    public void SetItem(ItemData item)
    {
        holdingItem = item;
        Debug.Log("手持：" + item.itemName);
    }

    public void ClearItem()
    {
        holdingItem = null;
        Debug.Log("清空手持");
    }
}