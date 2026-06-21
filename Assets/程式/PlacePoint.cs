using UnityEngine;

public class PlacePoint : MonoBehaviour
{
    public ItemData requiredItem;   // 正確物品
    public GameObject placedObject; // 放上去後顯示
    public GameObject hintUI;
    private bool canPlace;

    void Start()
    {
        if (placedObject != null)
            placedObject.SetActive(false);
    }

    void Update()
    {
        if (!canPlace) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerHoldItem player = FindFirstObjectByType<PlayerHoldItem>();

            if (player == null || !player.HasItem()) return;

            // ✔ 正確物品
            if (player.holdingItem == requiredItem)
            {
                Debug.Log("放置成功：" + requiredItem.itemName);

                player.ClearItem();

                if (placedObject != null)
                    placedObject.SetActive(true);
            }
            else
            {
                Debug.Log("物品不對，不能放");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            canPlace = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            canPlace = false;
    }
}