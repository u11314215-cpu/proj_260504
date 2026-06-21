using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<ItemData> items = new List<ItemData>();

    public Action onInventoryChanged;

    void Awake()
    {
        instance = this;
        items.Clear(); // 🔥 重要：避免殘留資料
    }

    public void AddItem(ItemData item)
    {
        items.Add(item);
        Debug.Log("撿到：" + item.itemName);

        onInventoryChanged?.Invoke();
    }
}