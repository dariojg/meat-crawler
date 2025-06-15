using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;
    public delegate void OnInventoryChangedEvent();
    public event OnInventoryChangedEvent OnInventoryChangedEventCallback;

    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    Dictionary<InventoryItemData, InventoryItem> InventoryDictionary = new Dictionary<InventoryItemData, InventoryItem>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddItem(InventoryItemData itemData)
    {
        if (InventoryDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack(1);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventoryItems.Add(newItem);
            InventoryDictionary.Add(itemData, newItem);
        }

        OnInventoryChangedEventCallback.Invoke();
    }

    public void RemoveItem(InventoryItemData itemData)
    {
        if (InventoryDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack(1);
        }
        if (item.StackSize == 0)
        {
            inventoryItems.Remove(item);
            InventoryDictionary.Remove(itemData);
        }

        OnInventoryChangedEventCallback.Invoke();
    }

}
