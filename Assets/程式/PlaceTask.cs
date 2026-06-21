using UnityEngine;

public class PlaceTask : MonoBehaviour
{
    public RitualManager ritualManager;

    public int taskID;
    public string requiredItemName;

    public GameObject placedObject;

    public void TryPlace()
    {
        if (Inventory.instance == null) return;

        // 找背包裡有沒有這個物品
        bool hasItem = Inventory.instance.items.Exists(
            x => x.itemName == requiredItemName
        );

        if (!hasItem)
        {
            Debug.Log("沒有正確物品");
            return;
        }

        if (placedObject != null)
            placedObject.SetActive(true);

        // 從背包移除（簡單版）
        ItemData item = Inventory.instance.items.Find(
            x => x.itemName == requiredItemName
        );

        if (item != null)
            Inventory.instance.items.Remove(item);

        


        if (ritualManager != null)
            ritualManager.CompleteTask(taskID);

        Debug.Log("放置成功");
    }
}