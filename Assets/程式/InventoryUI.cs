using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySlot[] slots;

    void Start()
    {
        Inventory.instance.onInventoryChanged += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
                slots[i].SetItem(Inventory.instance.items[i]);
            else
                slots[i].Clear();
        }
    }
}