using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    private GameObject inventoryUI;

    void Start()
    {
        inventoryUI = GameObject.Find("InventoryPanel");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventoryUI == null)
            {
                Debug.LogError("找不到 InventoryPanel，請確認名字是否正確");
                return;
            }

            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}