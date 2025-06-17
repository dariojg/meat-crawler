using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "Inventory/Item")]	// Como aparece en el menu de unity para crear un nuevo item
public class InventoryItemData : ScriptableObject
{
    [Tooltip("Unique identifier for the item")]
    public string id;
    
    [Tooltip("Display name of the item")]
    public string displayName;
    
    [Tooltip("Sprite, Icon of the item")]
    public Sprite icon;
    
    [Tooltip("Maximum number of items that can be stacked")]
    public int maxStacked;
    
    [Tooltip("Whether the item can be stacked")]
    public bool isStackable;
    
    [Tooltip("Item GameObject")]
    public GameObject prefab;
    
    [TextArea(10, 1000)]
    public string description = "This is a description of the item";
}
