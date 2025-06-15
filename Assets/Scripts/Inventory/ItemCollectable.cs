using UnityEngine;

public class ItemCollectable : MonoBehaviour
{
    [SerializeField]
    private bool isCollectable;
    public bool IsCollectable
    {
        get { return isCollectable; }
    }

    public InventoryItemData itemData;
    public void Pickup()
    {
        Inventory.instance.AddItem(itemData);
        Destroy(gameObject);
    }

}
