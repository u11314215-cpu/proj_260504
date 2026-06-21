using UnityEngine;


public class ItemPickup : MonoBehaviour
{
    public ItemData itemData;
    public GameObject interactUI;

    private bool canPickup;

    void Start()
    {
        if (interactUI != null)
            interactUI.SetActive(false);
    }

    void Update()
    {
        Debug.Log("ItemPickup running");

        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.AddItem(itemData);
            Destroy(gameObject);

            if (interactUI != null)
                interactUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = true;
            if (interactUI != null) interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canPickup = false;
            if (interactUI != null) interactUI.SetActive(false);
        }
    }
}