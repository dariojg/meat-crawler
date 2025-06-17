using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public GameObject itemSlotPrefab; // Prefab for the item slot UI
    [SerializeField]

    void Start()
    {
        Inventory.instance.OnInventoryChangedEventCallback += OnUpdateInventoryUI;
    }


    private void OnUpdateInventoryUI()
    {
        Debug.Log("Inventory UI Updated");

        foreach (Transform t in transform)
        {
            Destroy(t.transform.gameObject);
        }

        DrawInventoryUI();
    }

    private void DrawInventoryUI()
    {
        foreach (InventoryItem item in Inventory.instance.inventoryItems)
        {
           AddItemToSlot(item);
        }
    }

    private void AddItemToSlot(InventoryItem item)
    {
        GameObject gameObj = Instantiate(itemSlotPrefab);
        gameObj.transform.SetParent(transform, false); // Set parent and maintain local scale

        ItemSlot itemSlot = gameObj.GetComponent<ItemSlot>();
        if (itemSlot != null)
        {
            itemSlot.Set(item);
        }
        else
        {
            Debug.LogWarning("ItemSlot component not found on the prefab: " + item.data.prefab.name);
        }
    }
}
