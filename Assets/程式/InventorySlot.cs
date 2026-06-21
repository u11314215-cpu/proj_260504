using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI nameText;

    public ItemData item;
    public PlayerHoldItem playerHold;

    private float lastClickTime;
    private float doubleClickDelay = 0.3f;

    public void SetItem(ItemData item)
    {
        this.item = item;

        icon.sprite = item.icon;
        icon.enabled = true;

        nameText.text = item.itemName;

        transform.localScale = Vector3.one; // 正常大小
    }

    public void Clear()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        nameText.text = "";

        transform.localScale = Vector3.one;
    }

    public void OnClick()
    {
        if (item == null) return;

        // 🟡 雙擊判斷
        if (Time.time - lastClickTime < doubleClickDelay)
        {
            RemoveFromInventory();
        }
        else
        {
            SelectItem(); // 單擊：放大
        }

        lastClickTime = Time.time;
    }

    void SelectItem()
    {
        transform.localScale = Vector3.one * 1.2f;
    }

    void RemoveFromInventory()
    {
        Inventory.instance.items.Remove(item);
        Inventory.instance.onInventoryChanged?.Invoke();
    }
}